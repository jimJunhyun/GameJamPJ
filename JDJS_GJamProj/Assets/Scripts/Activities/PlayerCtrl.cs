using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCtrl : MonoBehaviour
{
	public float cooltime = 0.5f;
	public GameObject ShopPanel;
	
	Attacker myAtt;
	Vector2 dir;
	bool attackable = true;

	private void Awake()
	{
		//ShopPanel.SetActive(false);
		myAtt = GetComponent<Attacker>();
		StartCoroutine(Cooldown());
	}

    private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (transform.localPosition == Vector3.down)
			{
				transform.localPosition = Vector2.right;
				transform.eulerAngles = new Vector3(0, 0, 0);
			}
			else if (transform.localPosition == Vector3.left)
			{
				transform.localPosition = Vector2.down;
				transform.eulerAngles = new Vector3(0, 0, 270);
			}
			else if (transform.localPosition == Vector3.up)
			{
				transform.localPosition = Vector2.left;
				transform.eulerAngles = new Vector3(0, 0, 180);
			}
			else if (transform.localPosition == Vector3.right)
			{
				transform.localPosition = Vector2.up;
				transform.eulerAngles = new Vector3(0, 0, 90);
			}
		}
		if (Input.GetMouseButtonDown(0) && attackable)
		{
			myAtt.attackTrigger = true;
			attackable = false;
		}
	}

	IEnumerator Cooldown()
	{
		while (true)
		{
			yield return null;
			if (!attackable)
			{
				yield return new WaitForSeconds(cooltime);
				attackable = true;
			}

		}
	}
}
