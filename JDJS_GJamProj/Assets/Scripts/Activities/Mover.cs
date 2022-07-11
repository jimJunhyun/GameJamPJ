using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public Vector2 currentPos;
    public Vector2 targetPos;
    
    public bool stop = false;

    public Transform target;

    [Header("적일 경우 체크. 밑의 것은 방향 조정")]

    public bool isEnemy = true;

    public Transform direction;

    public float initDelay;
    public float conDelay;

    
    
    void Move()
	{
        Vector2 dir = Vector2.zero;
        if(currentPos.x != targetPos.x)
		{
            if (currentPos.x > targetPos.x)
            {
                dir = Vector2.left;
				if (isEnemy)
				{
                    direction.eulerAngles = new Vector3(0,0, 180);
				}
            }
            if (currentPos.x < targetPos.x)
            {
                dir = Vector2.right;
                if (isEnemy)
                {
                    direction.eulerAngles = new Vector3(0, 0, 0);
                }
            }
        }
        else if(currentPos.y != targetPos.y)
		{
            if (currentPos.y > targetPos.y)
            {
                dir = Vector2.down;
                if (isEnemy)
                {
                    direction.eulerAngles = new Vector3(0, 0, 270);
                }
            }
            if (currentPos.y < targetPos.y)
            {
                dir = Vector2.up;
                if (isEnemy)
                {
                    direction.eulerAngles = new Vector3(0, 0, 90);
                }
            }
        }
		if (isEnemy)
		{
            direction.localPosition = dir;
		}
        currentPos += dir;
	}

    IEnumerator DelayMove()
	{
        yield return new WaitForSeconds(initDelay);

        while (true)
		{
            yield return new WaitForSeconds(conDelay);
			if (stop)
			{
                stop = false;
                continue;
			}
            Move();
		}
	}

    // Start is called before the first frame update
    void Awake()
    {
        currentPos = transform.position;
        if(targetPos != null)
        { 
            targetPos = target.position;
        }
        StartCoroutine(DelayMove());
    }
	private void Update()
	{
        if(targetPos != null)
		{
            targetPos = target.position;
        }
		transform.position = currentPos;
	}
}
