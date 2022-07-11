using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpObject : MonoBehaviour
{
	public int maxHp;
	int currenthp;
    public Action<int> Damaged;

	void HpDecrease(int dam)
	{
		currenthp -= dam;
	}

	private void Awake()
	{
		currenthp = maxHp;
		Damaged = HpDecrease;
	}
	private void Update()
	{
		if(currenthp <= 0)
		{
			Destroy(gameObject);
		}
	}
}
