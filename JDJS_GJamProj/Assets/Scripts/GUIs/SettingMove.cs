using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SettingMove : MonoBehaviour
{
    [SerializeField] RectTransform MenuPanel;
    [SerializeField] RectTransform Setting;

    public bool onClick;
    
    public void OnSettingClick()
    {
        onClick = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        onClick = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
