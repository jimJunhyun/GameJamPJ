using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("다른 곳에서 게임 매니저 인스턴스를 설정함");
        }
        instance = this;
        CameraManager.instance = gameObject.AddComponent<CameraManager>();
    }

    void Update()
    {
        
    }
}
