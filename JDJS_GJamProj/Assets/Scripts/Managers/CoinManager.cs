using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;
	public int coinNum = 0;
	int prevNum;
	private void Awake()
	{
		Instance = this;
		prevNum = 0;
	}
	private void Update()
	{
		if(prevNum != coinNum)
		{
			prevNum = coinNum;
			GameUIManager.instane.CoinUIUpdate(prevNum);
		}
		if (Input.GetKeyDown(KeyCode.G))
		{
			coinNum += 100;
		}
	}
}
