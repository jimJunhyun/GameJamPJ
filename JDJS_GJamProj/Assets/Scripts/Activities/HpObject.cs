using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HpObject : MonoBehaviour
{
	public int maxHp;
	//[HideInInspector]
	public int currentHp;
    public Action<int> Damaged;
	public string HitTriggerName = "Hit";
	public UnityEvent OnHit;
	public UnityEvent OnDead;
	[SerializeField] GameObject dropCoin;
	public bool isPlayer;


	Animator anim;

	void HpDecrease(int dam)
	{
		if (isPlayer)
		{
			GameUIManager.instane.HitDmage(currentHp);
		}
		
		OnHit.Invoke();
		currentHp -= dam;
		
		anim.SetTrigger(HitTriggerName);
	}

	public void HpIncrease(int amount)
	{
		currentHp  = Mathf.Min(currentHp + amount, maxHp);
		GameUIManager.instane.HitDmage(currentHp + 1);
	}

	private void Start()
	{
		currentHp = maxHp;
		if (isPlayer)
		{
			GameUIManager.instane.InitHpUI(currentHp);
		}
		Damaged = HpDecrease;
		anim = GetComponent<Animator>();
	}
	private void Update()
	{
		if(currentHp <= 0)
		{
			if(dropCoin != null)
			{
				Instantiate(dropCoin, transform.position, Quaternion.identity);
			}
			OnDead.Invoke();
			if (!isPlayer)
			{
				Destroy(gameObject);
			}
			
			
		}
		
	}
}
