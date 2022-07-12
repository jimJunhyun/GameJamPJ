using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    public AttackRange range;
    public Transform attPos;

    public bool attackTrigger;

	[Tooltip("적들을 위한 공격 대리자. Mover에서 Invoke한다.")]
	public Action attack;

    void Attack()
	{
		
        range.transform.position = attPos.position;
        StartCoroutine(DelayOnOff());
	}

    IEnumerator DelayOnOff()
	{
        range.gameObject.SetActive(true);
		yield return new WaitForSeconds(0.1f);
        range.gameObject.SetActive(false);
	}

	private void Awake()
	{
		attack = Attack;
		range.gameObject.SetActive(false);
	}

	private void Update()
	{
		if (attackTrigger)
		{
			attackTrigger = false;
			Attack();
			
		}
	}
}
