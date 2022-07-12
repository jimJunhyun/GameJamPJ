using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpObject : MonoBehaviour
{
	public int maxHp;
	[HideInInspector]
	public int currentHp;
    public Action<int> Damaged;
	public string HitTriggerName = "Hit";
	[SerializeField] GameObject dropCoin;

	Animator anim;

	void HpDecrease(int dam)
	{
		currentHp -= dam;
		anim.SetTrigger(HitTriggerName);
	}

	private void Awake()
	{
		currentHp = maxHp;
		Damaged = HpDecrease;
		anim = GetComponent<Animator>();
	}
	private void Update()
	{
		if(currentHp <= 0)
		{
			Instantiate(dropCoin, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
		
	}
}
