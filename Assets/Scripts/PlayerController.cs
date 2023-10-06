using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public GameObject player;
    private Tweener tweener;

    public float speed = 0f;
    public float up = 0f;
    public float right = 0f;
    public float left = 0f;
    public float health = 1f;
    private Vector3 initialPlayerPosition;
    // Start is called before the first frame update
    void Start()
    {
        initialPlayerPosition = player.transform.position;
        tweener = GetComponent<Tweener>(); 
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("speed", speed);
        animator.SetFloat("right", right);
        animator.SetFloat("left", left);
        animator.SetFloat("up", up);
        animator.SetFloat("health", health);
        initialPlayerPosition = player.transform.position;

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            speed = 1;
            up = 1;
            tweener.AddTween(player.transform, initialPlayerPosition, new Vector3(0.0f, 0.5f, -2.0f), 1.5f);

        } else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            speed = 0;
            up = 0;
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            tweener.AddTween(player.transform, initialPlayerPosition, new Vector3(-2.0f, 0.5f, 0.0f), 1.5f);
            speed = 1;
            left = 1;
        }
        else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            speed = 0;
            left = 0;
            
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            speed = 1;
            right = 1;
            tweener.AddTween(player.transform, initialPlayerPosition, new Vector3(2.0f, 0.5f, 0.0f), 1.5f);
        }
        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            speed = 0;
            right = 0;
        }
        if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            speed = 1;
            tweener.AddTween(player.transform, initialPlayerPosition, new Vector3(0.0f, 0.5f, 2.0f), 1.5f);
        }
        else if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            speed = 0;
        }
        //Death preview
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            health = 0;
        }*/

    }
}
