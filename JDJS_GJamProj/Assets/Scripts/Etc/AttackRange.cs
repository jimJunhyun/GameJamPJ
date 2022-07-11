using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{

	public int damage;
	HpObject target;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if ((target = collision.GetComponent<HpObject>()) && target != GetComponentInParent<HpObject>())
		{
			Debug.Log("!!!?1");
			target.Damaged.Invoke(damage);
		}
	}
}
