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

	void HpDecrease(int dam)
	{
		currentHp -= dam;
	}

	private void Awake()
	{
		currentHp = maxHp;
		Damaged = HpDecrease;
	}
	private void Update()
	{
		if(currentHp <= 0)
		{
			Destroy(gameObject);
		}
	}
}
