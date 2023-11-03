using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{
    public float cherrySpeed = 2.0f; // Adjust the cherry's speed
    public Vector3[] path;
    private int currentPathIndex = 0;
    private float journeyLength;
    private float startTime;
    private Vector3 startPosition;
    private Vector3 endPosition;

    private void Start()
    {
        path = new Vector3[]
{
            new Vector3(26.0f, -6.5f, 0.0f),
            new Vector3(-8f, -6.5f, 0.0f),
};
        startPosition = path[currentPathIndex];
        endPosition = path[currentPathIndex + 1];
        transform.position = startPosition;
        startTime = Time.time;

        journeyLength = Vector3.Distance(startPosition, endPosition);
    }

    private void Update()
    {
        float distanceCovered = (Time.time - startTime) * cherrySpeed;
        float journeyFraction = distanceCovered / journeyLength;

        if (journeyFraction < 1.0f)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, journeyFraction);
        }
        else
        {
            currentPathIndex++;
            if (currentPathIndex >= path.Length - 1)
            {
                currentPathIndex = 0;
            }

            startTime = Time.time;
            startPosition = path[currentPathIndex];
            endPosition = path[currentPathIndex + 1];
        }
    }
}
