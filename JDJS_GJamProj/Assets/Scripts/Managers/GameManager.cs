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
            Debug.LogError("�ٸ� ������ ���� �Ŵ��� �ν��Ͻ��� ������");
        }
        instance = this;
        CameraManager.instance = gameObject.AddComponent<CameraManager>();
    }

    void Update()
    {
        
    }
}
