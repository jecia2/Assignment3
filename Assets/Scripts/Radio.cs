using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    public AudioSource intro;
    public AudioSource collision;
    public AudioSource catDeath;
    public AudioSource ghostDeath;
    public AudioSource ghostScared;
    public AudioSource pellets;
    public AudioSource walkingSound;
    public AudioSource background;
    // Start is called before the first frame update
    void Start()
    {
        intro.Play();
        float introLength = intro.clip.length;
        background.PlayDelayed(introLength);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            walkingSound.Play();
        }
        else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            walkingSound.Stop();
        }

    }
}
