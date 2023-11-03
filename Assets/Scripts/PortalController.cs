using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    private Transform destination;

    public bool isLeft;
    public float distance = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        if (isLeft == false)
        {
            destination = GameObject.FindGameObjectWithTag("rightTeleporter").GetComponent<Transform>();
        }
        else
        {
            destination = GameObject.FindGameObjectWithTag("leftTeleporter").GetComponent<Transform>();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(Vector2.Distance(transform.position, other.transform.position) > distance)
        {
            Debug.Log("Teleport");
            other.transform.position = new Vector2(destination.position.x, destination.position.y);
        }
    }
}
