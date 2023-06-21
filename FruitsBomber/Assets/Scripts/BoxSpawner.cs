using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public GameObject[] Boxes;
    public Transform[] BoxSpawners;
    public Transform[] BoxTo;
    public float speed = 10.0f;
    public AudioClip boxScore;

    private GameObject scoreManager = null;
    private ScoreManager sm = null;

    private AudioSource audioSource = null;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager");
        sm = scoreManager.GetComponent<ScoreManager>();

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] AppleBoxes = GameObject.FindGameObjectsWithTag("AppleBox");
        foreach (GameObject AppleBox in AppleBoxes)
        {

            MoveAppleBoxes(AppleBox);
        }
        
        GameObject[] BlueberryBoxes = GameObject.FindGameObjectsWithTag("BlueberryBox");
        foreach (GameObject BlueberryBox in BlueberryBoxes)
        {

            MoveBlueberryBoxes(BlueberryBox);
        }

        GameObject[] OrangeBoxes = GameObject.FindGameObjectsWithTag("OrangeBox");
        foreach (GameObject OrangeBox in OrangeBoxes)
        {

            MoveOrangeBoxes(OrangeBox);
        }

        GameObject[] WatermelonBoxes = GameObject.FindGameObjectsWithTag("WatermelonBox");
        foreach (GameObject WatermelonBox in WatermelonBoxes)
        {

            MoveWatermelonBoxes(WatermelonBox);
        }
    }

    public void SpawnBox(int fruit)
    {
        Instantiate(Boxes[fruit], BoxSpawners[fruit].position, Quaternion.identity);
    }

    public void MoveAppleBoxes(GameObject AppleBox)
    {
        if (Vector2.Distance(AppleBox.transform.position, BoxTo[0].transform.position) > 0.01f)
        {
            AppleBox.transform.position = Vector2.MoveTowards(AppleBox.transform.position, BoxTo[0].transform.position, speed * Time.deltaTime);
        }
        else
        {
            Destroy(AppleBox);
            sm.scoreTextApple.text = "x " + sm.scoreApple;
            audioSource.PlayOneShot(boxScore);

        }
    }

    public void MoveBlueberryBoxes(GameObject BlueberryeBox)
    {
        if (Vector2.Distance(BlueberryeBox.transform.position, BoxTo[1].transform.position) > 0.01f)
        {
            BlueberryeBox.transform.position = Vector2.MoveTowards(BlueberryeBox.transform.position, BoxTo[1].transform.position, speed * Time.deltaTime);
        }
        else
        {
            Destroy(BlueberryeBox);
            sm.scoreTextBlueberry.text = "x " + sm.scoreBlueberry;
            audioSource.PlayOneShot(boxScore);
        }
    }

    public void MoveOrangeBoxes(GameObject OrangeBox)
    {
        if (Vector2.Distance(OrangeBox.transform.position, BoxTo[2].transform.position) > 0.01f)
        {
            OrangeBox.transform.position = Vector2.MoveTowards(OrangeBox.transform.position, BoxTo[2].transform.position, speed * Time.deltaTime);
        }
        else
        {
            Destroy(OrangeBox);
            sm.scoreTextOrange.text = "x " + sm.scoreOrange;
            audioSource.PlayOneShot(boxScore);
        }
    }

    public void MoveWatermelonBoxes(GameObject WatermeloneBox)
    {
        if (Vector2.Distance(WatermeloneBox.transform.position, BoxTo[3].transform.position) > 0.01f)
        {
            WatermeloneBox.transform.position = Vector2.MoveTowards(WatermeloneBox.transform.position, BoxTo[3].transform.position, speed * Time.deltaTime);
        }
        else
        {
            Destroy(WatermeloneBox);
            sm.scoreTextWatermelon.text = "x " + sm.scoreWatermelon;
            audioSource.PlayOneShot(boxScore);
        }
    }
}
