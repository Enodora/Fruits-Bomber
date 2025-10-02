using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public GameObject scoreText;
    public GameObject gameOverCanvas;
    public GameObject gmObject;
    public AudioClip explosionSE;
    private GameManager gm = null;
    private GameObject msUIObject;
    private MoveScoreUI msUI = null;
    private bool isGameOverUI = false;
    private bool once = true;

    // Start is called before the first frame update
    void Start()
    {
        gmObject = GameObject.Find("GameManager");
        gm = gmObject.GetComponent<GameManager>();

        msUIObject = GameObject.Find("ScoreFruit");
        msUI = msUIObject.GetComponent<MoveScoreUI>();

        gameOverCanvas.SetActive(false);
        scoreText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOverUI)
        {
            msUI.slideUI();

            GameObject existSafe = GameObject.FindGameObjectWithTag("safe");
            if (existSafe == null)
            {
                if (msUI.moveUIDone)
                {
                    gameOverCanvas.SetActive(true);

                    // GoogleAdMobController.AdmobManager.ShowInterstitialAd();
                }
            }
        }
    }

    public void GameOver()
    {
        if (once)
        {
            once = false;
            scoreText.SetActive(true);
            gm.PlaySE(explosionSE);

            isGameOverUI = true;
            GameObject[] unsafeObjects = GameObject.FindGameObjectsWithTag("unsafe");
            foreach (GameObject unsafeObject in unsafeObjects)
            {
                ItemManager im = unsafeObject.GetComponent<ItemManager>();
                im.PlayExplosion();
                GameObject.Destroy(unsafeObject, 0.34f);
            }

            gm.endSpawn();
        }
    }
}
