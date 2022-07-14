using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
	public Attacker att;
	private void Start()
	{
		
		Time.timeScale = 0f;
	}
	public void SelectWeapon(int val)
	{
		att.attackNo = val;
	}
	public void Disabler()
	{
		Time.timeScale = 1;
		gameObject.SetActive(false);
	}
}
