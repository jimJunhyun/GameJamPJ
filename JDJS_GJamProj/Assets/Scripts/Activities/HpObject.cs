using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Audio;
public class HpObject : MonoBehaviour
{
	public int maxHp;
	//[HideInInspector]
	public int currentHp;
    public Action<int> Damaged;
	public string HitTriggerName = "Hit";
	public UnityEvent OnHit;
	public UnityEvent OnDead;
	[SerializeField] GameObject dropCoin;
	public bool isPlayer;
	public AudioSource audioSource;


	Animator anim;

	void HpDecrease(int dam)
	{
		OnHit.Invoke();
		currentHp -= dam;
		
		anim.SetTrigger(HitTriggerName);
	}

	public void HpIncrease(int amount)
	{
		currentHp  = Mathf.Min(currentHp + amount, maxHp);
	}

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
		currentHp = maxHp;
		Damaged = HpDecrease;
		anim = GetComponent<Animator>();
	}
	private void Update()
	{
		if(currentHp <= 0)
		{
			if(dropCoin != null)
			{
				Instantiate(dropCoin, transform.position, Quaternion.identity);
			}
			OnDead.Invoke();
			if (!isPlayer)
			{
				Destroy(gameObject);
			}
			
			
		}
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
		if (collision.CompareTag("Spikes"))
        {
			audioSource.Play();
			currentHp -= 1;
			Debug.Log(currentHp);
        }
    }
}
