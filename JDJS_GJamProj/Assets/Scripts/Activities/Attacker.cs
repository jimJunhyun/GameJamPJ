using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    public AttackRange range;
    public Transform attPos;

    public bool attackTrigger;

	[Tooltip("������ ���� ���� �븮��. Mover���� Invoke�Ѵ�.")]
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
