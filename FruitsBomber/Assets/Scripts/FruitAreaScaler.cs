using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitAreaScaler : MonoBehaviour
{
    private GameObject blueberryArea;
    private GameObject appleArea;
    private GameObject orangeArea;
    private GameObject watermelonArea;

    // Start is called before the first frame update
    void Start()
    {
        blueberryArea = GameObject.Find("BlueberryAreaPiviotPoint");
        appleArea = GameObject.Find("AppleAreaPiviotPoint");
        orangeArea = GameObject.Find("OrangeAreaPiviotPoint");
        watermelonArea = GameObject.Find("WatermelonAreaPiviotPoint");

        if ((float)Screen.height / (float)Screen.width >= 2.1f)
        {
            blueberryArea.transform.localScale = new Vector3(1.3f, 1.5f, 1);
            appleArea.transform.localScale = new Vector3(1.3f, 1.5f, 1);
            orangeArea.transform.localScale = new Vector3(1.3f, 1.5f, 1);
            watermelonArea.transform.localScale = new Vector3(1.3f, 1.5f, 1);
        }
        else if ((float)Screen.height / (float)Screen.width >= 2.0f)
        {
            blueberryArea.transform.localScale = new Vector3(1.3f, 1.3f, 1);
            appleArea.transform.localScale = new Vector3(1.3f, 1.3f, 1);
            orangeArea.transform.localScale = new Vector3(1.3f, 1.3f, 1);
            watermelonArea.transform.localScale = new Vector3(1.3f, 1.3f, 1);
        }
        else if ((float)Screen.height / (float)Screen.width >= 1.7f)
        {
            blueberryArea.transform.localScale = new Vector3(1.2f, 1.2f, 1);
            appleArea.transform.localScale = new Vector3(1.2f, 1.2f, 1);
            orangeArea.transform.localScale = new Vector3(1.2f, 1.2f, 1);
            watermelonArea.transform.localScale = new Vector3(1.2f, 1.2f, 1);
        }
        else
        {
            blueberryArea.transform.localScale = new Vector3(1, 1, 1);
            appleArea.transform.localScale = new Vector3(1, 1, 1);
            orangeArea.transform.localScale = new Vector3(1, 1, 1);
            watermelonArea.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
