using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUICtrl : MonoBehaviour
{
    Slider bar;
    public HpObject hp;

	int prevHp = 0;

	private void Awake()
	{
		bar = GetComponentInChildren<Slider>();
	}

	private void Update()
	{
		if(prevHp != hp.currentHp)
		{
			prevHp = hp.currentHp;
			bar.value = prevHp;
		}
	}
}
