using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;
	public int coinNum = 0;
	int prevNum;
	AudioSource audioSource;
    public AudioClip getCoins;
    public AudioClip buyItem;
	private void Awake()
	{
		audioSource = gameObject.GetComponent<AudioSource>();
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
	public void GetCoins()
    {
		audioSource.clip = getCoins;
		audioSource.Play();
    }
	public void BuyItem()
    {
		audioSource.clip = buyItem;
		audioSource.Play();
    }
}
