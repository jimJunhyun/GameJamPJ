using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
	public string detectTag;
	public int damage;

	bool damaged;

	HpObject target;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if ((target = collision.GetComponent<HpObject>()) && target != GetComponentInParent<HpObject>() && target.CompareTag(detectTag) && !damaged)
		{
			target.Damaged.Invoke(damage);
			damaged = false;
		}
	}
}
