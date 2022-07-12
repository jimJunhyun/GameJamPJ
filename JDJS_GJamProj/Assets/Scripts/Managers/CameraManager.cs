using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{   
    public static CameraManager instance;
    CinemachineVirtualCamera VCam;
    void Start()
    {
        VCam = GameObject.Find("CMVcam").GetComponent<CinemachineVirtualCamera>();
    }
    public void MoveCMVcam(Transform mapTrm)
    {
        VCam.Follow = mapTrm;
    }
}
