using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float timerInterval;
    private float timer = 15;
    public float speed = 5.0f;
    private float firstInterval = 3.0f;
    private float secondInterval = 2.0f;
    private float thirdInterval = 1.0f;
    private float fourthInterval = 0.8f;
    [HideInInspector] public bool isDead = false;
    public bool isFirst = true;
    public bool isSecond = false;
    public bool isThird = false;
    public bool isFourth = false;
    private int currentInternal = 1;
    private bool checkInterval = true;
    public GameObject[] Fruit;
    public Transform[] spawnPoint;
    [HideInInspector] public bool isGameOver = false;

    public GameObject wallL;
    public GameObject wallR;
    public GameObject wallT;
    public GameObject wallB;

    private AudioSource audioSource = null;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        timer = timerInterval;
        checkInterval = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (checkInterval)
        {
            continueSpeed();
            checkInterval = false;
        }

        timer -= Time.deltaTime;

        if (!isDead && isFirst)
        {
            InvokeRepeating("Spawn", 0.1f, firstInterval);
            timer = timerInterval;
            isFirst = false;
            isSecond = true;
        }
        else if (timer <= 0 && !isDead && isSecond)
        {
            CancelInvoke("Spawn");
            InvokeRepeating("Spawn", 0.1f, secondInterval);
            timer = timerInterval;
            isSecond = false;
            isThird = true;
        }
        else if (timer <= 0 && !isDead && isThird)
        {
            speed = 150;
            CancelInvoke("Spawn");
            InvokeRepeating("Spawn", 0.1f, thirdInterval);
            timer = timerInterval;
            isThird = false;
            isFourth = true;
        }
        else if (timer <= 0 && !isDead && isFourth)
        {
            CancelInvoke("Spawn");
            InvokeRepeating("Spawn", 0.1f, fourthInterval);
            isFourth = false;
        }
    }

    void Spawn()
    {
        if (!isGameOver)
        {
            int fruitRandomNum = Random.Range(0, 4);
            int spawnRandomNum = Random.Range(0, 4);
            GameObject newFruit = Instantiate(Fruit[fruitRandomNum], spawnPoint[spawnRandomNum].position, Quaternion.identity) as GameObject;
            newFruit.name = Fruit[fruitRandomNum].name;

            if (spawnRandomNum == 0)
            {
                newFruit.GetComponent<Rigidbody2D>().AddForce(Vector3.down * speed);
            }
            else if (spawnRandomNum == 1)
            {
                newFruit.GetComponent<Rigidbody2D>().AddForce(Vector3.right * speed);
            }
            else if (spawnRandomNum == 2)
            {
                newFruit.GetComponent<Rigidbody2D>().AddForce(Vector3.left * speed);
            }
            else if (spawnRandomNum == 3)
            {
                newFruit.GetComponent<Rigidbody2D>().AddForce(Vector3.up * speed);
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void endSpawn()
    {
        CancelInvoke("Spawn");
        isDead = true;
    }

    public void PlaySE(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public void saveSpeed()
    {
        if (isSecond)
            currentInternal = 1;
        else if (isThird)
            currentInternal = 2;
        else if (isFourth)
            currentInternal = 3;
        else
            currentInternal = 4;

        PlayerPrefs.SetInt("CURRENTSPEED", currentInternal);
    }
    public void continueSpeed()
    {
        switch (PlayerPrefs.GetInt("CURRENTSPEED"))
        {
            case 1:
                isFirst = true;
                isSecond = false;
                isThird = false;
                isFourth = false;
                break;
            case 2:
                isFirst = false;
                isSecond = true;
                isThird = false;
                isFourth = false;
                timer = 0;
                break;
            case 3:
                isFirst = false;
                isSecond = false;
                isThird = true;
                isFourth = false;
                timer = 0;
                break;
            case 4:
                isFirst = false;
                isSecond = false;
                isThird = false;
                isFourth = true;
                timer = 0;
                break;
        }
    }

    public void resetSpeed()
    {
        currentInternal = 1;
        PlayerPrefs.SetInt("CURRENTSPEED", currentInternal);
    }
}