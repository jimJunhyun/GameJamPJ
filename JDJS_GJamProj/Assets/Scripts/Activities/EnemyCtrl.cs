using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    Attacker attack;
    DetectRange detect;
    Mover move;
	private void Awake()
	{
		attack = GetComponentInChildren<Attacker>();
		detect = GetComponentInChildren<DetectRange>();
		move = GetComponent<Mover>();
	}
	// Update is called once per frame
	void Update()
    {
		if (detect.detected)
		{
			move.stop = true;
		}
    }
}
