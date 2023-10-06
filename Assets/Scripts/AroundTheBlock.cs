using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AroundTheBlock : MonoBehaviour
{
    public Animator animator;
    public AudioSource movingAudio;
    private Vector3[] path;
    private int currentPathIndex = 0;
    private float journeyLength;
    public float journeySpeed = 2.0f;
    public float speed = 0f;
    private float startTime;
    private Vector3 startPosition;
    private Vector3 endPosition;

    void Start()
    {
        path = new Vector3[]
        {
            new Vector3(0.0f, 0.41f, 0.0f),
            new Vector3(-3.57f, 0.47f, 0.0f),
            new Vector3(-3.57f, 3.1f, 0.0f),
            new Vector3(1.03f, 3.1f, 0.0f),
            new Vector3(0.0f, 0.41f, 0.0f),
        };
        startPosition = path[currentPathIndex];
        endPosition = path[currentPathIndex + 1];
        transform.position = startPosition;
        startTime = Time.time;

        journeyLength = Vector3.Distance(startPosition, endPosition);

        if (movingAudio != null)
        {
            movingAudio.Play();
        }
    }

    void Update()
    {
        float distanceCovered = (Time.time - startTime) * journeySpeed;
        float journeyFraction = distanceCovered / journeyLength;

        if (journeyFraction < 1.0f)
        {
            transform.Rotate(0f, 0f, 90f);
            transform.position = Vector3.Lerp(startPosition, endPosition, journeyFraction);
            animator.SetFloat("speed", speed);
            speed = 1f;
        }
        else
        {
            currentPathIndex++;
            if (currentPathIndex >= path.Length - 1)
            {
                currentPathIndex = 0;
            }

            speed = 0f;
            startTime = Time.time;
            startPosition = path[currentPathIndex];
            endPosition = path[currentPathIndex + 1];
        }
    }
}
