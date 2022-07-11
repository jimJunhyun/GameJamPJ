using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{

	public int damage;
	HpObject target;

	private void OnEnable()
	{
		Debug.Log("!!?!?!?!?!");
		transform.position += new Vector3(Random.Range(-0.01f, 0.01f), Random.Range(-0.01f, 0.01f));
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if ((target = collision.GetComponent<HpObject>()) && target != GetComponentInParent<HpObject>())
		{
			target.Damaged.Invoke(damage);
		}
	}
}
