using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCtrl : MonoBehaviour
{
	BossAttacker attack;
	DetectRange detect;
	BossMover move;
	private void Awake()
	{
		attack = GetComponentInChildren<BossAttacker>();
		detect = GetComponentInChildren<DetectRange>();
		move = GetComponent<BossMover>();
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
