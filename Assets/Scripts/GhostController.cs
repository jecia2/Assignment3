using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    public Animator defaultAnimator;
    public Animator blueAnimator;
    public Animator greenAnimator;
    public Animator purpleAnimator;

    public float scared = 0f;
    public float duckHealth = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        defaultAnimator.SetFloat("scared", scared);
        blueAnimator.SetFloat("scared", scared);
        greenAnimator.SetFloat("scared", scared);
        purpleAnimator.SetFloat("scared", scared);


        //dummy to test animation
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            scared = 1;
        }
        else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            scared = 0;
        }

    }
}
