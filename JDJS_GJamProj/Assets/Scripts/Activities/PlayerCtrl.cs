using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class PlayerCtrl : MonoBehaviour
{
	public float cooltime = 0.5f;
	public GameObject ShopPanel;
	public Text stageText;
	
	Transform currentStage;
	ShopDetect detect;
	Attacker myAtt;
	Vector2 dir;

	bool attackable = true;


	private void Awake()
	{

		//ShopPanel.SetActive(false);
		detect = GetComponent<ShopDetect>();
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
		if (Input.GetMouseButtonDown(0) && attackable && !detect.shopping)
		{
			myAtt.attackTrigger = true;
			attackable = false;
		}
		Collider2D box = Physics2D.OverlapBox(transform.position, Vector2.one * 0.5f, 0f, 1 << 6);
		if (box)
		{
			//if(currentStage != null)
			//{
			//	currentStage.GetComponentsInChildren<Mover>(stageEnemys);
			//	for (int i = 0; i < stageEnemys.Count; i++)
			//	{
			//		stageEnemys[i].direction.gameObject.SetActive(false);
			//		stageEnemys[i].enabled = false;
			//	}
			//}
			currentStage = box.transform.parent.GetComponent<Transform>();
			CameraManager.instance.MoveCMVcam(currentStage);
			Debug.Log(currentStage.GetComponent<StageData>());
			stageText.text = "1-" + currentStage.GetComponent<StageData>().Stagedata;
			//currentStage.GetComponentsInChildren<Mover>(stageEnemys);
			//for (int i = 0; i < stageEnemys.Count; i++)
			//{
			//	stageEnemys[i].direction.gameObject.SetActive(true);
			//	stageEnemys[i].enabled = true;
			//}
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
