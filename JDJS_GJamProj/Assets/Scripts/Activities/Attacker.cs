using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    public AttackRange range;
    public Transform attPos;

    public bool attackTrigger;

    void Attack()
	{
        range.transform.position = attPos.position;
        StartCoroutine(DelayOnOff());
	}

    IEnumerator DelayOnOff()
	{
        range.gameObject.SetActive(true);
		range.transform.position += new Vector3(Random.Range(-0.01f, 0.01f), Random.Range(-0.01f, 0.01f));

		yield return null;
        range.gameObject.SetActive(false);
	}

	private void Awake()
	{
		range.gameObject.SetActive(false);
	}

	private void Update()
	{
		if (attackTrigger)
		{
			Attack();
			attackTrigger = false;
		}
	}
}
