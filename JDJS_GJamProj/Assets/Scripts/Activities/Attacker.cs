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

	public bool isRandomAttack = false;

	[Tooltip("적들을 위한 공격 대리자. Mover에서 Invoke한다.")]
	public Action attack;
	
	[HideInInspector]
	public int attackNo;

    void Attack()
	{
        range[attackNo].transform.position = attPos[attackNo].position;
        StartCoroutine(DelayOnOff());
	}

    IEnumerator DelayOnOff()
	{
		if (preAttackWarn)
		{
			if (warningRange != null)
			{
				warningRange[attackNo].SetActive(true);
				yield return new WaitForSeconds(0.2f);
				warningRange[attackNo].SetActive(false);
			}

			range[attackNo].gameObject.SetActive(true);
			yield return new WaitForSeconds(0.1f);
			range[attackNo].gameObject.SetActive(false);
		}
		else
		{
			
			range[attackNo].gameObject.SetActive(true);
			yield return new WaitForSeconds(0.25f);
			range[attackNo].gameObject.SetActive(false);
			if (warningRange != null)
			{
				warningRange[attackNo].SetActive(true);
				yield return new WaitForSeconds(0.1f);
				warningRange[attackNo].SetActive(false);
			}
		}
	}

	private void Awake()
	{
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
		if (isRandomAttack)
		{
			attackNo = UnityEngine.Random.Range(0, range.Count);
		}
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
