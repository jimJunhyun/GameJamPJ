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
        //player ���ݷ� +
    }
    public void BlueBigPotionClick()
    {
        bigBluePotion.SetActive(false);
        //player ���ݼӵ� +
    }
    public void GreenBigPotionClick()
    {
        bigGreenPotion.SetActive(false);
        //player ü�� +
    }
    public void YellowBigPotionClick()
    {
        bigYellowPotion.SetActive(false);
        //player �̵��ӵ�
    }

    // Start is called before the first frame update
    void Start()
    {
        //player�� �޾ƿ;���
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
