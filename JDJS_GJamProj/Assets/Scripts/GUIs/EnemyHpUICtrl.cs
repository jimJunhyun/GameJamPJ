using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpUICtrl : MonoBehaviour
{
    HpObject hp;
    Slider bar;

    int prevVal;
    // Start is called before the first frame update
    void Awake()
    {
        hp = GetComponentInParent<HpObject>();
        bar = GetComponent<Slider>();
        prevVal = hp.maxHp;
    }
	private void Update()
	{
		if(prevVal != hp.currentHp)
		{
            bar.value = prevVal;

		}
	}
}
