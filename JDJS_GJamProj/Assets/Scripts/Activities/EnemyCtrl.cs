using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    DetectRange detect;
    Mover move;
	private void Awake()
	{
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
