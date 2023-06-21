using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScoreUI : MonoBehaviour
{
    public GameObject moveUI;
    public GameObject[] movePoint;
    public float speed = 5.0f;
    [HideInInspector] public bool moveUIDone = false;

    private Rigidbody2D rb = null;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveUI.transform.position = movePoint[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void slideUI()
    {
        if (Vector2.Distance(transform.position, movePoint[1].transform.position) > 0.1f)
        {
            Vector2 toVector = Vector2.MoveTowards(transform.position, movePoint[1].transform.position, speed * Time.deltaTime);
            rb.MovePosition(toVector);
        }
        else
        {
            moveUIDone = true;
        }
    }
}
