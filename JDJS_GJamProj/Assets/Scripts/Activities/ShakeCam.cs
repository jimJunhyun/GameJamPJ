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
	CinemachineVirtualCamera cmvCam;

	private void Awake()
	{
		cmvCam = GetComponent<CinemachineVirtualCamera>();
		noise = cmvCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
	}
	public void Shake()
	{
		if(!invoking)
			StartCoroutine(Shaker());
	}
	IEnumerator Shaker()
	{
		invoking = true;
		noise.m_AmplitudeGain = shakeStrength;
		yield return new WaitForSeconds(shakeTime);
		noise.m_AmplitudeGain  =0f;
		invoking = false;
	}
}
