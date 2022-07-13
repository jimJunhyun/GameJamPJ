using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    public List<AttackRange> range = new List<AttackRange>();
    public List<Transform> attPos = new List<Transform>();
	public List<GameObject> warningRange = new List<GameObject>();
	public bool attackTrigger;

	public bool preAttackWarn = true;

	public bool isBoss = false;

	public bool isRandomAttack = false;

	[Tooltip("적들을 위한 공격 대리자. Mover에서 Invoke한다.")]
	public Action attack;
	
	[HideInInspector]
	public int attackNo;

	Animator anim;

    void Attack()
	{
		if (isRandomAttack)
		{
			attackNo = UnityEngine.Random.Range(0, range.Count);
		}
		range[attackNo].transform.position = attPos[attackNo].position;
        StartCoroutine(DelayOnOff());
	}

    IEnumerator DelayOnOff()
	{
		if (preAttackWarn)
		{
			if (isBoss)
			{
				Debug.Log("!");
				anim.SetInteger("BossAttacker", attackNo);
				anim.SetBool("Attack", true);
			}
			
			if (warningRange != null)
			{
				warningRange[attackNo].SetActive(true);
				yield return new WaitForSeconds(0.2f);
				warningRange[attackNo].SetActive(false);
			}

			range[attackNo].gameObject.SetActive(true);
			yield return new WaitForSeconds(0.1f);
			range[attackNo].gameObject.SetActive(false);
			if (isBoss)
			{
				anim.SetInteger("BossAttacker", -1);
				anim.SetBool("Attack", false);
				Debug.Log("??");
			}
			
		}
		else
		{
			if (isBoss)
			{
				anim.SetInteger("BossAttacker", attackNo);
				anim.SetBool("Attack", true);
			}
			
			range[attackNo].gameObject.SetActive(true);
			yield return new WaitForSeconds(0.25f);
			range[attackNo].gameObject.SetActive(false);
			if (warningRange != null)
			{
				warningRange[attackNo].SetActive(true);
				yield return new WaitForSeconds(0.1f);
				warningRange[attackNo].SetActive(false);
			}
			if (isBoss)
			{
				anim.SetInteger("BossAttacker", -1);
				anim.SetBool("Attack", false);
			}
			
		}
	}

	private void Awake()
	{
		anim = GetComponent<Animator>();
		attack = Attack;
		for (int i = 0; i < warningRange.Count; i++)
		{
			warningRange[i].SetActive(false);
		}
		for (int i = 0; i < range.Count; i++)
		{
			range[i].gameObject.SetActive(false);
		}
		
	}

	private void Update()
	{
		
		if (Input.GetKeyDown(KeyCode.R) && !isRandomAttack)
		{
			attackNo += 1;
			if (attackNo >= range.Count)
			{
				attackNo = 0;
			}
		}
		if (attackTrigger)
		{
			
			attackTrigger = false;
			Attack();
		}
		
	}
}
