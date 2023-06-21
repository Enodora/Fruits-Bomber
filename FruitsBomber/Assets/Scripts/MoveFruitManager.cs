using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFruitManager : MonoBehaviour
{
    public GameObject moveTowards = null;
    public float pullSpeed = 5.0f;
    public AudioClip fruitScore;
    public float timer = 1.0f;

    private GameObject gmObject = null;
    private GameManager gm = null;
    private GameObject scoreManager = null;
    private ScoreManager sm = null;

    // Start is called before the first frame update
    void Start()
    {
        gmObject = GameObject.Find("GameManager");
        gm = gmObject.GetComponent<GameManager>();

        scoreManager = GameObject.Find("ScoreManager");
        sm = scoreManager.GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.isDead)
        {
            timer -= Time.deltaTime;
        }
        if (gm.isDead && timer < 0)
        {
            GameObject[] unsafeObjects = GameObject.FindGameObjectsWithTag("safe");
            foreach (GameObject scoreFruit in unsafeObjects)
            {
                moveFruits(scoreFruit);
            }
        }
    }

    void moveFruits(GameObject scoreFruit)
    {
        if (Vector2.Distance(scoreFruit.transform.position, moveTowards.transform.position) > 0.1f)
        {
            scoreFruit.transform.position = Vector2.MoveTowards(scoreFruit.transform.position, moveTowards.transform.position, pullSpeed * Time.deltaTime);
        }
        else
        {
            Destroy(scoreFruit);
            sm.addFruitScore();
            gm.PlaySE(fruitScore);
        }
    }
}
