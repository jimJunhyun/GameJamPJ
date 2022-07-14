using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class CameraManager : MonoBehaviour
{   
    public static CameraManager instance;
    CinemachineVirtualCamera VCam;

    void Start()
    {
        VCam = GameObject.Find("CMVcam").GetComponent<CinemachineVirtualCamera>();
        VCam.Follow = GameObject.Find("Map0").GetComponent<Transform>();
    }
    public void MoveCMVcam(Transform mapTrm)
    {
        VCam.Follow = mapTrm;
    }
}
