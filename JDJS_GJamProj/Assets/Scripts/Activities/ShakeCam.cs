using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCam : MonoBehaviour
{
    public float shakeStrength;
	public Vector2 shakeLimit;
	bool invoking = false;
    public void Shake()
	{
		if(!invoking)
			StartCoroutine(Shaker());
	}
	IEnumerator Shaker()
	{
		invoking = true;
		Vector3 startPos = transform.position;
		for (int i = 0; i < 100; i++)
		{
			yield return null;
			Vector3 shakeOffset = Random.insideUnitCircle * shakeStrength;
			if(transform.position.x + shakeOffset.x > startPos.x + shakeLimit.x || transform.position.x - shakeOffset.x < startPos.x - shakeLimit.x)
			{
				shakeOffset.x = 0;
			}
			if (transform.position.y + shakeOffset.y> startPos.y + shakeLimit.y || transform.position.y - shakeOffset.y < startPos.y - shakeLimit.y)
			{
				shakeOffset.y = 0;
			}
			transform.position += shakeOffset;
		}

		transform.position = startPos;
		invoking = false;
	}
}
