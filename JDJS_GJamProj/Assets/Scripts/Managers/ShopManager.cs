using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ShopManager : MonoBehaviour
{
    [SerializeField] GameObject bigRedPotion;
    [SerializeField] GameObject bigBluePotion;
    [SerializeField] GameObject bigGreenPotion;
    [SerializeField] GameObject bigYellowPotion;
    
    public void RedBigPotionClick()
    {
        bigRedPotion.SetActive(false);
        //player 공격력 +
    }
    public void BlueBigPotionClick()
    {
        bigBluePotion.SetActive(false);
        //player 공격속도 +
    }
    public void GreenBigPotionClick()
    {
        bigGreenPotion.SetActive(false);
        //player 체력 +
    }
    public void YellowBigPotionClick()
    {
        bigYellowPotion.SetActive(false);
        //player 이동속도
    }

    // Start is called before the first frame update
    void Start()
    {
        //player를 받아와야함
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
