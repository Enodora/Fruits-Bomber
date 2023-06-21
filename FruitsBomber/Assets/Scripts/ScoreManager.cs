using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text highScoreText = null;
    public Text goScoreText = null;
    public Text scoreText = null;
    public Text scoreTextApple = null;
    public Text scoreTextWatermelon = null;
    public Text scoreTextOrange = null;
    public Text scoreTextBlueberry = null;
    public Text scoreRemaining = null;
    public GameObject scoreRemain;
    public GameObject moveToScore;

    public AudioClip NineFruitSE = null;
    public AudioClip fruitsScore;

    private int highScore = 0;
    [HideInInspector] public int score = 0;
    [HideInInspector] public int scoreApple = 0;
    [HideInInspector] public int scoreWatermelon = 0;
    [HideInInspector] public int scoreOrange = 0;
    [HideInInspector] public int scoreBlueberry = 0;

    private GameObject gmObject = null;
    private GameManager gm = null;
    private GameObject BoxSpawnerObj = null;
    private GameObject bmObject = null;
    private ButtonManager bm = null;
    private BoxSpawner boxSpawn = null;
    private bool once = true;
    private bool moveRemainText = false;
    private bool checkRetry = true;
    private bool isRetry = false;
    //[HideInInspector] public bool retry = true;
    public int counter = 9;
    [HideInInspector] public int counterApple = 0;
    [HideInInspector] public int counterWatermelon = 0;
    [HideInInspector] public int counterOrange = 0;
    [HideInInspector] public int counterBlueberry = 0;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();

        gmObject = GameObject.Find("GameManager");
        gm = gmObject.GetComponent<GameManager>();

        BoxSpawnerObj = GameObject.Find("BoxSpawner");
        boxSpawn = BoxSpawnerObj.GetComponent<BoxSpawner>();

        bmObject = GameObject.Find("ButtonManager");
        bm = bmObject.GetComponent<ButtonManager>();

        scoreTextApple.GetComponent<Text>();
        scoreTextApple.text = "x " + PlayerPrefs.GetInt("SCOREApple");

        scoreTextWatermelon.GetComponent<Text>();
        scoreTextWatermelon.text = "x " + PlayerPrefs.GetInt("SCOREWatermelon");

        scoreTextOrange.GetComponent<Text>();
        scoreTextOrange.text = "x " + PlayerPrefs.GetInt("SCOREOrange");

        scoreTextBlueberry.GetComponent<Text>();
        scoreTextBlueberry.text = "x " + PlayerPrefs.GetInt("SCOREBlueberry");

        scoreRemaining.GetComponent<Text>();
        scoreRemaining.text = "x " + PlayerPrefs.GetInt("SCORERemaining");

        scoreText.GetComponent<Text>();
        scoreText.text = "Score " + score;

        highScoreText.GetComponent<Text>();
        goScoreText.GetComponent<Text>();

        highScore = PlayerPrefs.GetInt("HIGHSCORE");
        highScoreText.text = "High Score " + highScore;

        scoreApple = PlayerPrefs.GetInt("SCOREApple");
        scoreWatermelon = PlayerPrefs.GetInt("SCOREWatermelon");
        scoreOrange = PlayerPrefs.GetInt("SCOREOrange");
        scoreBlueberry = PlayerPrefs.GetInt("SCOREBlueberry");
    }

    // Update is called once per frame
    void Update()
    {
        if (checkRetry && PlayerPrefs.GetInt("boolRetry")==1)
        {
            scoreRemain.SetActive(true);
            checkRetry = false;
            isRetry = true;
        }
        else if(checkRetry)
        {
            scoreRemain.SetActive(false);
            checkRetry = false;
            isRetry = false;
        }
        if (PlayerPrefs.GetInt("HIGHSCORE") < score)
        {
            PlayerPrefs.SetInt("HIGHSCORE", score);
            highScoreText.text = "High Score " + PlayerPrefs.GetInt("HIGHSCORE");
        }

        goScoreText.text = scoreText.text;

        nineFruits();

        if (gm.isDead && once)
        {
            score += (scoreApple + scoreWatermelon + scoreBlueberry + scoreOrange) * counter;
            scoreText.text = "Score " + score;

            once = false;
            moveRemainText = true;
        }
        if (isRetry && moveRemainText && Vector2.Distance(scoreRemain.transform.position, moveToScore.transform.position) > 0.1f)
        {
            scoreRemain.transform.position = Vector2.MoveTowards(scoreRemain.transform.position, moveToScore.transform.position, 5 * Time.deltaTime);
        }
        else if(isRetry && moveRemainText)
        {
            scoreRemain.SetActive(false);
            score += score += PlayerPrefs.GetInt("SCORERemaining");
            scoreText.text = "Score " + score;
            gm.PlaySE(fruitsScore);
            moveRemainText = false;
        }
    }

    public void addFruitScore()
    {
        score++;
        scoreText.text = "Score " + score;
    }

    void nineFruits()
    {
        if (counterApple == counter)
        {
            scoreApple++;
            counterApple = 0;

            GameObject[] safes = GameObject.FindGameObjectsWithTag("safe");
            GameObject[] apples = GameObject.FindGameObjectsWithTag("Apple");
            int first = 0;
            for (int i = 0; i < safes.Length; i++)
            {
                for (int y = 0; y < apples.Length; y++)
                {
                    GameObject original = apples[y].transform.parent.gameObject;
                    if (original == safes[i])
                    {
                        Destroy(original);
                        boxSpawn.SpawnBox(0);
                        first++;
                        if (first == 9)
                        {
                            gm.PlaySE(NineFruitSE);
                        }
                    }
                }
            }
        }
        else if (counterWatermelon == counter)
        {
            scoreWatermelon++;
            counterWatermelon = 0;

            GameObject[] safes = GameObject.FindGameObjectsWithTag("safe");
            GameObject[] watermelons = GameObject.FindGameObjectsWithTag("Watermelon");
            int first = 0;
            for (int i = 0; i < safes.Length; i++)
            {
                for (int y = 0; y < watermelons.Length; y++)
                {
                    GameObject original = watermelons[y].transform.parent.gameObject;
                    if (original == safes[i])
                    {
                        Destroy(original);
                        boxSpawn.SpawnBox(3);
                        first++;
                        if (first == 9)
                        {
                            gm.PlaySE(NineFruitSE);
                        }
                    }
                }
            }
        }
        else if (counterOrange == counter)
        {
            scoreOrange++;
            counterOrange = 0;

            GameObject[] safes = GameObject.FindGameObjectsWithTag("safe");
            GameObject[] oranges = GameObject.FindGameObjectsWithTag("Orange");
            int first = 0;
            for (int i = 0; i < safes.Length; i++)
            {
                for (int y = 0; y < oranges.Length; y++)
                {
                    GameObject original = oranges[y].transform.parent.gameObject;
                    if (original == safes[i])
                    {
                        Destroy(original);
                        boxSpawn.SpawnBox(2);
                        first++;
                        if (first == 9)
                        {
                            gm.PlaySE(NineFruitSE);
                        }
                    }
                }
            }
        }
        else if (counterBlueberry == counter)
        {
            scoreBlueberry++;
            counterBlueberry = 0;

            GameObject[] safes = GameObject.FindGameObjectsWithTag("safe");
            GameObject[] blueberries = GameObject.FindGameObjectsWithTag("Blueberry");
            int first = 0;
            for (int i = 0; i < safes.Length; i++)
            {
                for (int y = 0; y < blueberries.Length; y++)
                {
                    GameObject original = blueberries[y].transform.parent.gameObject;
                    if (original == safes[i])
                    {
                        Destroy(original);
                        boxSpawn.SpawnBox(1);
                        first++;
                        if (first == 9)
                        {
                            gm.PlaySE(NineFruitSE);
                        }
                    }
                }
            }
        }
    }

    public void saveScore()
    {
        PlayerPrefs.SetInt("SCOREApple", scoreApple);
        PlayerPrefs.SetInt("SCOREWatermelon", scoreWatermelon);
        PlayerPrefs.SetInt("SCOREOrange", scoreOrange);
        PlayerPrefs.SetInt("SCOREBlueberry", scoreBlueberry);
        PlayerPrefs.SetInt("SCORERemaining", score-(9*(scoreApple + scoreWatermelon + scoreOrange + scoreBlueberry)));
        PlayerPrefs.SetInt("boolRetry",  1);
    }
    public void resetScore()
    {
        score = 0;
        scoreApple = 0;
        scoreWatermelon = 0;
        scoreOrange = 0;
        scoreBlueberry = 0;

        PlayerPrefs.SetInt("SCOREApple", scoreApple);
        PlayerPrefs.SetInt("SCOREWatermelon", scoreWatermelon);
        PlayerPrefs.SetInt("SCOREOrange", scoreOrange);
        PlayerPrefs.SetInt("SCOREBlueberry", scoreBlueberry);
        PlayerPrefs.SetInt("SCORERemaining", 0);
        PlayerPrefs.SetInt("boolRetry", 0);
    }
}
