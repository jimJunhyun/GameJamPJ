using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public static GameUIManager instane;
    [SerializeField] Image heartImage = null;
    [SerializeField] Image halfHeartImage = null;
    [SerializeField] Image emptyHeart = null;
    [SerializeField] Text stageText;
    [SerializeField] Text coinCntTxt;
    //[SerializeField] Button StatusBT;
    [SerializeField] RectTransform StatusPanel;
    [SerializeField] RectTransform hpPanel;
    bool OntheStatus = false;
    int coinCnt;

	private void Awake()
	{
        instane = this;
    }

	void Start()
    {
        StatusPanel.gameObject.SetActive(false);
        //StartCoroutine("OnStatus");
    }
    private void Update()
    {

        Vector2 mousePos = Input.mousePosition;
        //string message = mousePos.ToString();
        //Debug.Log(message);
        if (mousePos.x <= 1890 && mousePos.x >= 1650 && mousePos.y >= 31.8 && mousePos.y <= 77.6)
        {
            StatusPanel.gameObject.SetActive(true);
        }
        else
        {
            StatusPanel.gameObject.SetActive(false);
        }
    }
    public void InitHpUI(int maxHP)
    {
        for (int i = 0; i < maxHP / 2; i++)
        {
            Instantiate(heartImage, hpPanel);
        }
        if (maxHP % 2 == 1)
        {
            Instantiate(halfHeartImage, hpPanel);
        }

    }
    public void HitDmage(int hitBeforeHP)
    {
        Debug.Log(hitBeforeHP / 2);
        Debug.Log(hpPanel.transform.GetChild(1));
        Image heart = hitBeforeHP % 2 == 1 ?
            hpPanel.transform.GetChild(hitBeforeHP / 2).GetComponent<Image>() : hpPanel.transform.GetChild((hitBeforeHP / 2) - 1).GetComponent<Image>();
        if (hitBeforeHP % 2 == 1)
        {
            heart.sprite = emptyHeart.sprite;
        }
        else
        {
            heart.sprite = halfHeartImage.sprite;
        }
    }
    public void GetCoin()
    {
        coinCntTxt.text = $"{++coinCnt}";
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
