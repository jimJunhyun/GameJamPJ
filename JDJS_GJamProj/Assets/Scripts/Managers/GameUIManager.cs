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
    [SerializeField] Image Panel;
    [SerializeField] Text ATK;
    [SerializeField] Text ASPD;
    [SerializeField] Text SPD;

    AttackRange attackRange;
    PlayerCtrl attackSpeed;
    float time = 0;
    float ftime = 1f;
    bool OntheStatus = false;
    int coinCnt;


	private void Awake()
	{
        instane = this;
        StartCoroutine("Fade");
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
        if (mousePos.x <= 1919 && mousePos.x >= 1719 && mousePos.y >= 31.8 && mousePos.y <= 77.6)
        {
            StatusPanel.gameObject.SetActive(true);
            //ATK.text = "ATK : " + attackRange.damage;
            //ASPD.text = "ASPD : " + attackSpeed.cooltime;
        }
        else
        {
            StatusPanel.gameObject.SetActive(false);
        }
    }

    IEnumerator Fade()
    {
        Panel.gameObject.SetActive(true);
        Color alpha = Panel.color;
        while (alpha.a >= 0f)
        {
            time += Time.deltaTime / ftime;
            alpha.a = Mathf.Lerp(1, 0, time);
            Panel.color = alpha;
            yield return null;
        }
        yield return null;
    }
    public void CoinUIUpdate(int val)
    {
        coinCntTxt.text = $"{val}";
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
