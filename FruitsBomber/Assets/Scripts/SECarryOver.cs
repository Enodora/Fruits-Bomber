using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SECarryOver : MonoBehaviour
{
    public bool DontDestroy = true;
    public AudioClip pressStart;

    private AudioSource audioSource = null;

    // Start is called before the first frame update
    void Start()
    {

        audioSource = GetComponent<AudioSource>();

        if (DontDestroy)
        {
            DontDestroyOnLoad(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playSE()
    {
        audioSource.PlayOneShot(pressStart);
    }
}
