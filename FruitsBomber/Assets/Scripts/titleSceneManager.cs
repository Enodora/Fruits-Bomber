using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class titleSceneManager : MonoBehaviour
{
    private GameObject SEcarryOverObject = null;
    private SECarryOver SECO = null;

    private AsyncOperation async;
    public GameObject loadingCanvas;
    public Slider loadingSlider;

    // Start is called before the first frame update
    void Start()
    {
        SEcarryOverObject = GameObject.Find("SoundEffectCarryOver");
        SECO = SEcarryOverObject.GetComponent<SECarryOver>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton()
    {
        PlayerPrefs.SetInt("CONTINUECOUNTER", 0);
        PlayerPrefs.SetInt("CURRENTSPEED", 1);
        PlayerPrefs.SetInt("SCOREApple", 0);
        PlayerPrefs.SetInt("SCOREWatermelon", 0);
        PlayerPrefs.SetInt("SCOREOrange", 0);
        PlayerPrefs.SetInt("SCOREBlueberry", 0);
        PlayerPrefs.SetInt("SCORERemaining", 0);
        PlayerPrefs.SetInt("boolRetry", 0);

        SECO.playSE();
        loadingCanvas.SetActive(true);
        StartCoroutine("LoadScene");
        
    }

    IEnumerator LoadScene()
    {
        async = SceneManager.LoadSceneAsync("Stage1");

        while (!async.isDone)
        {
            var progressVal = Mathf.Clamp01(async.progress / 0.9f);
            loadingSlider.value = progressVal;
            yield return null;
        }
    }
}
