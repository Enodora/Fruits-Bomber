using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitAreaManager : MonoBehaviour
{
    [HideInInspector] public string deleteArea = "";
    private GameObject gmObject;
    private GameManager gm = null;
    private bool once = true;
    // Start is called before the first frame update
    void Start()
    {
        gmObject = GameObject.Find("GameManager");
        gm = gmObject.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (once && !deleteArea.Equals(""))
        {
            switch (deleteArea)
            {
                case "AppleArea":
                    GameObject[] apples = GameObject.FindGameObjectsWithTag("Apple");
                    foreach (GameObject apple in apples)
                    {
                        GameObject original = apple.transform.parent.gameObject;

                        ItemManager im = original.GetComponent<ItemManager>();
                        im.PlayExplosion();

                        Destroy(original, 0.34f);
                    }
                    break;
                case "OrangeArea":
                    GameObject[] oranges = GameObject.FindGameObjectsWithTag("Orange");
                    foreach (GameObject orange in oranges)
                    {
                        GameObject original = orange.transform.parent.gameObject;

                        ItemManager im = original.GetComponent<ItemManager>();
                        im.PlayExplosion();

                        Destroy(original, 0.34f);
                    }
                    break;
                case "WatermelonArea":
                    GameObject[] watermelons = GameObject.FindGameObjectsWithTag("Watermelon");
                    foreach (GameObject watermelon in watermelons)
                    {
                        GameObject original = watermelon.transform.parent.gameObject;

                        ItemManager im = original.GetComponent<ItemManager>();
                        im.PlayExplosion();

                        Destroy(original, 0.34f);
                    }
                    break;
                case "BlueberryArea":
                    GameObject[] blueberries = GameObject.FindGameObjectsWithTag("Blueberry");
                    foreach (GameObject blueberry in blueberries)
                    {
                        GameObject original = blueberry.transform.parent.gameObject;

                        ItemManager im = original.GetComponent<ItemManager>();
                        im.PlayExplosion();

                        Destroy(original, 0.34f);
                        Debug.Log("Might be this one: " + original.tag);
                    }
                    break;
            }
            once = false;
        }
        
    }
}
