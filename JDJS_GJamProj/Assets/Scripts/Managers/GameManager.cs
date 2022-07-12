using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    void Awake()
    {
        if (instance != null)
            Debug.LogError("�ٸ� ������ ���� �Ŵ��� �ν��Ͻ��� ������");
        instance = this;
        if (CameraManager.instance != null)
            Debug.LogError("�ٸ� ������ ī�޶� �Ŵ��� �ν��Ͻ��� ������");
        CameraManager.instance = gameObject.AddComponent<CameraManager>();
        if (GameUIManager.instane != null)
            Debug.LogError("�ٸ� ������ ���� UI �Ŵ��� �ν��Ͻ��� ������");
        GameUIManager.instane = GetComponent<GameUIManager>();
    }

    void Update()
    {

    }
}
