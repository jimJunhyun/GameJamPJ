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
        prevVal = 0;
    }
	private void Update()
	{
		if(prevVal != hp.currentHp)
		{
            prevVal = hp.currentHp;
            bar.value = prevVal;

		}
	}
}
