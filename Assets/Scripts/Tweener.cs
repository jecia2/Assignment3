using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweener : MonoBehaviour
{
    private Tween activeTween;

    public void AddTween(Transform targetObject, Vector3 startPos, Vector3 endPos, float duration)
    {
        if (activeTween == null)
        {
            activeTween = new Tween(targetObject, startPos, endPos, Time.time, duration);
            Debug.Log("Tween here");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activeTween != null)
        {
            float targetDist = Vector3.Distance(activeTween.Target.position, activeTween.EndPos);
            //divide elapsed time by duration
            float timeStuff = (Time.time - activeTween.StartTime) / activeTween.Duration;
            float percentage = timeStuff / targetDist;
            //Debug.Log(percentage);
            //Debug.Log("yippee");
            if (targetDist > 0.1f)
            {
                activeTween.Target.position = Vector3.Lerp(activeTween.StartPos, activeTween.EndPos, percentage);
            }
            else if (targetDist <= 0.1f)
            {
                activeTween.Target.position = activeTween.EndPos;
                activeTween = null;
            }
        }

    }
}
