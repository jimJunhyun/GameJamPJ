using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    public List<AttackRange> range = new List<AttackRange>();
    public Transform attPos;
	public List<GameObject> warningRange = new List<GameObject>();
	public List<AudioClip> attackSound = new List<AudioClip>();
	public bool attackTrigger;
	public AudioSource attackAudioSource;

	public bool preAttackWarn = true;

	public bool isRandomAttack;

	[Tooltip("적들을 위한 공격 대리자. Mover에서 Invoke한다.")]
	public Action attack;
	
	//[HideInInspector]
	public int attackNo;
	int prevAttNo;
	bool frameWait = false;

    void Attack()
	{
		if (isRandomAttack)
		{
			attackNo = UnityEngine.Random.Range(0, range.Count);
		}
		for (int i = 0; i < range.Count; i++)
		{
			range[i].gameObject.SetActive(false);
		}
        range[attackNo].transform.position = attPos.position;
		
		
		StartCoroutine(DelayOnOff());
		StartCoroutine(DelayOff());
	}

	IEnumerator DelayOff()
	{
		frameWait = true;
		yield return null;
		frameWait = false;
		attackTrigger = false;
	}

    IEnumerator DelayOnOff()
	{
		
		if (attackSound != null)
		{
			attackAudioSource.clip = attackSound[attackNo];
			attackAudioSource.Play();
		}
		
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


	private void LateUpdate()
	{
		if(prevAttNo != attackNo)
		{
			for (int i = 0; i < range.Count; i++)
			{
				range[i].gameObject.SetActive(false);
			}
			prevAttNo = attackNo;
		}
		if (attackTrigger && !frameWait)
		{
			
			Attack();
			
		}
		
	}
}
