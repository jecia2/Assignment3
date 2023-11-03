using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    private Transform pacStudent;
    //private Vector3 currentTarget;
    //private bool isMoving = false;
    public Animator defaultAnimator;
    public Animator blueAnimator;
    public Animator greenAnimator;
    public Animator purpleAnimator;
    public float scared = 0f;

    void Start()
    {
        //pacStudent = GameObject.FindWithTag("Player").transform;
        //currentTarget = pacStudent.position;
    }

    void Update()
    {
        defaultAnimator.SetFloat("scared", scared);
        blueAnimator.SetFloat("scared", scared);
        greenAnimator.SetFloat("scared", scared);
        purpleAnimator.SetFloat("scared", scared);
      /*  if (!isMoving)
        {
            currentTarget = pacStudent.position;
            MoveToTarget(currentTarget);
        }*/
    }

    /*void MoveToTarget(Vector3 target)
    {
        isMoving = true;
        StartCoroutine(MoveCoroutine(target));
    }

    IEnumerator MoveCoroutine(Vector3 target)
    {
        while (transform.position != target)
        {
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, step);

            yield return null;
        }

        isMoving = false;
    }*/
}
