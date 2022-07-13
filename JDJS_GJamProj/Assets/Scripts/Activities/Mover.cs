using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public GameObject ShopPanel;
    public Vector2 currentPos;
    public Vector2 targetPos;
    
    public bool stop = false;

    public Transform target;

    public int ignoreLayer = 2;
    public int ignoreLayer2 = 6;

    public string runBoolName = "Run";
    public string idleBoolName = "Idle";

    [Header("적일 경우 체크. 밑의 것은 방향 조정자")]

    public bool isEnemy = true;

    public Transform direction;

    public float initDelay;
    public float conDelay;

    bool isInvoking = false;
    Vector2 dir = Vector2.zero;
    Attacker attack;
    Animator anim;
    SpriteRenderer sprite;

    void Move()
	{
        
        if (Mathf.Abs(currentPos.x - targetPos.x) >= Mathf.Abs(currentPos.y - targetPos.y))
        {
            
            if (currentPos.x > targetPos.x)
            {
                dir = Vector2.left;
                sprite.flipX = true;
                if (isEnemy)
                {
                    direction.eulerAngles = new Vector3(0, 0, 180);
                }
            }
            if (currentPos.x < targetPos.x)
            {
                dir = Vector2.right;
                sprite.flipX = false;
                if (isEnemy)
                {
                    direction.eulerAngles = new Vector3(0, 0, 0);
                }
            }
            if (isEnemy)
            {
                direction.localPosition = dir;
            }
        }
        else if (Mathf.Abs(currentPos.x - targetPos.x) < Mathf.Abs(currentPos.y - targetPos.y))
        {
            if (currentPos.y > targetPos.y)
            {
                dir = Vector2.down;
                sprite.flipX = true;
                if (isEnemy)
                {
                    direction.eulerAngles = new Vector3(0, 0, 270);
                }
            }
            if (currentPos.y < targetPos.y)
            {
                dir = Vector2.up;
                sprite.flipX = false;
                if (isEnemy)
                {
                    direction.eulerAngles = new Vector3(0, 0, 90);
                }
            }
            if (isEnemy)
            {
                direction.localPosition = dir;
            }
        }
        if (!Physics2D.OverlapBox(direction.position, Vector2.one * 0.5f, 0f, ignoreLayer))
		{
            
            currentPos += dir;
        }
    }

    private void OnDrawGizmos()
	{
		Gizmos.DrawWireCube(direction.position, Vector2.one * 0.5f);
	}

	IEnumerator DelayMove()
	{
        yield return new WaitForSeconds(initDelay);

        while (true)
		{
            yield return new WaitForSeconds(conDelay);
            if(target != null)
			{
                
                if (stop)
                {
                    if (isEnemy)
                    {
                        attack.attack.Invoke();
                    }
                    stop = false;
                    continue;
                }
                Move();
            }
			
		}
	}

    IEnumerator LerpMove()
	{
        anim.SetBool(runBoolName, true);
        anim.SetBool(idleBoolName, false);
        Vector2 prevPos = transform.position;
        float t = 0;
        while (t < conDelay / 2)
		{
            yield return null;
            t += Time.deltaTime;
            transform.position = Vector3.Lerp(prevPos, currentPos, t / (conDelay / 2));
		}
        anim.SetBool(runBoolName, false);
        anim.SetBool(idleBoolName, true);
        isInvoking = false;
        
    }

    public bool Approximate(float a, float b, float err)
	{
        return Mathf.Abs(a - b) < err;
	}

	private void OnBecameVisible()
	{
		if (isEnemy)
		{
            Debug.Log("VISIBLE  " + transform.name);
            target = GameObject.Find("Player").transform;
        }
        
        
	}

	private void OnBecameInvisible()
	{
        Debug.Log("InVISIBLE  " + transform.name);
        target = null;
	}

	// Start is called before the first frame update
	void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        attack = GetComponent<Attacker>();
		//if (isEnemy)
		//{
  //          target = GameObject.Find("Player").transform;
		//}
        currentPos = transform.position;
        if(targetPos != null && target != null)
        { 
            targetPos = target.position;
        }
        ignoreLayer  = ~(1 << ignoreLayer) & ~(1<<ignoreLayer2);
        
        StartCoroutine(DelayMove());
    }
	private void Update()
	{
        if (targetPos != null && target != null)
		{
            targetPos = target.position;
        }
        if ((transform.position.x != currentPos.x || transform.position.y != currentPos.y) && !isInvoking)
        {
            isInvoking = true;
            StartCoroutine(LerpMove());
        }

    }

}
