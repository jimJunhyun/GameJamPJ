using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] Text stageText;
    //[SerializeField] Button StatusBT;
    [SerializeField] GameObject StatusPanel;
    bool OntheStatus = false;
    
    void Start()
    {
        StatusPanel.SetActive(false);
        //StartCoroutine("OnStatus");
    }
    private void Update()
    {
        
        Vector2 mousePos = Input.mousePosition;
        string message = mousePos.ToString();
        Debug.Log(message);
        if (mousePos.x <= 1890 && mousePos.x >= 1650 && mousePos.y >= 31.8 && mousePos.y <= 77.6)
        {
            StatusPanel.SetActive(true);
        }
        else
        {
            StatusPanel.SetActive(false);
        }
    }

    //IEnumerator OnStatus()
    //{
    //    while (true)
    //    {
    //        if(OntheStatus == true)
    //        {
    //            OntheStatus = false;
    //        }
    //    }
    //}

}
