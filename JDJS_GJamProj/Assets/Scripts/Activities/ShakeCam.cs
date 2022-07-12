using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ShakeCam : MonoBehaviour
{
    public float shakeStrength;
	public float shakeTime;
	bool invoking = false;
	public CinemachineBasicMultiChannelPerlin noise;

	private void Awake()
	{
		noise = GetComponent<CinemachineBasicMultiChannelPerlin>();
	}
	public void Shake()
	{
		if(!invoking)
			StartCoroutine(Shaker());
	}
	IEnumerator Shaker()
	{
		invoking = true;
		noise.enabled = true;
		yield return new WaitForSeconds(shakeTime);
		noise.enabled = false;
		invoking = false;
	}
}
