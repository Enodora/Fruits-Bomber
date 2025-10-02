using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private GameObject topWall;
    private GameObject leftWall;
    private GameObject rightWall;
    private GameObject bottomWall;


    public float destroyTime = 15.0f;
    private float timer = 0;
    private float blinkTime = 0.4f;
    private bool isInBox = false;
    private bool firstIn = true;
    private GameObject gmObject = null;
    private GameManager gm = null;
    private GameObject goObject = null;
    private GameOverManager gom = null;
    private GameObject scoreManager = null;
    private ScoreManager sm = null;
    private GameObject famObject = null;
    private FruitAreaManager fam = null;
    private GameObject bmObject = null;
    private ButtonManager bm = null;

    private Collider2D col = null;
    private Animator anim;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        topWall = GameObject.Find("WallMiddle");
        leftWall = GameObject.Find("WallLeft");
        rightWall = GameObject.Find("WallRight");
        bottomWall = GameObject.Find("WallBottom");

        gmObject = GameObject.Find("GameManager");
        gm = gmObject.GetComponent<GameManager>();

        goObject = GameObject.Find("GameOver");
        gom = goObject.GetComponent<GameOverManager>();

        scoreManager = GameObject.Find("ScoreManager");
        sm = scoreManager.GetComponent<ScoreManager>();

        famObject = GameObject.Find("FruitArea");
        fam = famObject.GetComponent<FruitAreaManager>();

        bmObject = GameObject.Find("ButtonManager");
        bm = bmObject.GetComponent<ButtonManager>();

        col = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        timer = destroyTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gm.isDead) 
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftWall.transform.position.x+0.15f, rightWall.transform.position.x-0.15f), Mathf.Clamp(transform.position.y, bottomWall.transform.position.y+0.15f, topWall.transform.position.y-0.15f), transform.position.z);
        }
        
        if (gm.isDead)
        {
            col.isTrigger = true;
            GetComponent<Rigidbody2D>().linearVelocity = Vector3.zero;
            GetComponent<Rigidbody2D>().angularVelocity = 0.0f;
        }
    }

    void FixedUpdate()
    {
        destroyTime -= Time.deltaTime;
        if (destroyTime <= 3 && destroyTime > 0 && !isInBox)
        {
            blinkTime -= Time.deltaTime;
            if (blinkTime >= 0.2)
            {
                sr.enabled = false;
            }
            else if (blinkTime < 0.2 && blinkTime > 0)
            {
                sr.enabled = true;
            }
            else
            {
                blinkTime = 0.4f;
            }
        }
        else if (destroyTime <= 0 && !isInBox)
        {
            gom.GameOver();
        }
    }

    void OnMouseDrag()
    {
        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;
        float z = 100.0f;
        if (!bm.getPaused() && !gm.isGameOver && this.gameObject.tag == "unsafe")
        {
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(x, y, z));
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        sr.enabled = true;

        string fruit = gameObject.name;
        if (fruit+"Area" == col.gameObject.tag)
        {
            this.gameObject.tag = "safe";
            if (firstIn)
            {
                isInBox = true;

                switch (fruit)
                {
                    case "Apple":
                        sm.counterApple++;
                        break;
                    case "Orange":
                        sm.counterOrange++;
                        break;
                    case "Watermelon":
                        sm.counterWatermelon++;
                        break;
                    case "Blueberry":
                        sm.counterBlueberry++;
                        break;
                }
                firstIn = false;
            }
        }
        else
        {
            fam.deleteArea = col.gameObject.tag;
            gom.GameOver();
        }
    }

    public void PlayExplosion()
    {
        anim.Play("Explosion");
    }
}
