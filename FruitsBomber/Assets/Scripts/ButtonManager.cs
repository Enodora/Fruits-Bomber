using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public GameObject pauseCanvas;
    public GameObject continueText;
    // public GameObject WatchToContinue;

    private GameObject gmObject;
    private GameManager gm = null;
    private GameObject smObject;
    private ScoreManager sm = null;

    private bool watchedAd = false;
    private bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        gmObject = GameObject.Find("GameManager");
        gm = gmObject.GetComponent<GameManager>();
        smObject = GameObject.Find("ScoreManager");
        sm = smObject.GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {

        // if (PlayerPrefs.GetInt("CONTINUECOUNTER") == 0)
        // {
        //     WatchToContinue.SetActive(true);
        // }
        // else
        // {
        //     WatchToContinue.SetActive(false);
        // }

        if (!watchedAd)
        {
            continueText.SetActive(false);
        }
    }

    public void Retry()
    {
        sm.resetScore();
        gm.resetSpeed();
        PlayerPrefs.SetInt("CONTINUECOUNTER", 0);
        // WatchToContinue.SetActive(true);
        sm.scoreRemain.SetActive(false);
        SceneManager.LoadScene("Stage1");
    }

    public void DisplayContinue()
    {
        PlayerPrefs.SetInt("CONTINUECOUNTER", 1);
        watchedAd = true;
        continueText.SetActive(true);
    }

    public void continueGame()
    {
        gm.saveSpeed();
        sm.saveScore();
        watchedAd = true;
        SceneManager.LoadScene("Stage1");
    }
    public bool getPaused()
    {
        return isPaused;
    }
    public void Pause()
    {
        isPaused = true;
        pauseCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1;
        pauseCanvas.SetActive(false);
    }

    public void toTitle()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Title");
    }
}
