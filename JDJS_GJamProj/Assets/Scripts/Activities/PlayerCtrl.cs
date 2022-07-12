using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
	public Weapon weapon;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			weapon.Attack();
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			transform.localPosition = Vector2.left;
		}
		else if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			transform.localPosition = Vector2.right;
		}
		else if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			transform.localPosition = Vector2.up;
		}
		else if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			transform.localPosition = Vector2.down;
		}
	}
}
