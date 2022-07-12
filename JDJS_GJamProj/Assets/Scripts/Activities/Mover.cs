using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public Vector2 currentPos;
    public Vector2 targetPos;

    public Transform target;

    public float initDelay;
    public float conDelay;

    public Animator animator;

    void Move()
    {
        Vector2 dir = Vector2.zero;
        if (currentPos.x != targetPos.x)
        {
            if (currentPos.x > targetPos.x)
            {
                dir = Vector2.left;
            }
            if (currentPos.x < targetPos.x)
            {
                dir = Vector2.right;
            }
        }
        else if (currentPos.y != targetPos.y)
        {
            if (currentPos.y > targetPos.y)
            {
                dir = Vector2.down;
            }
            if (currentPos.y < targetPos.y)
            {
                dir = Vector2.up;
            }
        }
        currentPos += dir;
        animator.SetTrigger("IsMove");
    }

    IEnumerator DelayMove()
    {
        yield return new WaitForSeconds(initDelay);

        while (true)
        {
            yield return new WaitForSeconds(conDelay);
            Move();
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        currentPos = transform.position;
        if (targetPos != null)
        {
            targetPos = target.position;
        }
        StartCoroutine(DelayMove());
    }
    private void Update()
    {
        if (targetPos != null)
        {
            targetPos = target.position;
        }
        transform.position = currentPos;
    }
}
