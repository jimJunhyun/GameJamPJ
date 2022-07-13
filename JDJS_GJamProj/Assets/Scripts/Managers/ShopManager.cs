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

    [SerializeField] Text bigRedPotionVal;
    [SerializeField] Text bigBluePotionVal;
    [SerializeField] Text bigGreenPotionVal;
    [SerializeField] Text bigYellowPotionVal;

    int redVal;
    int blueVal;
    int greenVal;
    int yellowVal;
    
    GameObject player;
    Mover playerMover;
    List<AttackRange> playerAttack = new List<AttackRange>();
    PlayerCtrl playerCont;
    HpObject playerHp;
    
    public void RedBigPotionClick()
    {
        if(redVal <= CoinManager.Instance.coinNum)
		{
            CoinManager.Instance.BuyItem();
            CoinManager.Instance.coinNum -= redVal;
            bigRedPotion.SetActive(false);
			for (int i = 0; i < playerAttack.Count; i++)
			{
                playerAttack[i].damage += 1;
            }
            
        }
        
    }
    public void BlueBigPotionClick()
    {
        if (blueVal <= CoinManager.Instance.coinNum)
        {
            CoinManager.Instance.BuyItem();
            CoinManager.Instance.coinNum -= blueVal;
            bigBluePotion.SetActive(false);
            playerCont.cooltime -= 0.25f;
        }
        
    }
    public void GreenBigPotionClick()
    {
        if (greenVal <= CoinManager.Instance.coinNum)
        {
            CoinManager.Instance.BuyItem();
            CoinManager.Instance.coinNum -= greenVal;
            bigGreenPotion.SetActive(false);
            playerHp.maxHp += 2;
        }
        
    }
    public void YellowBigPotionClick()
    {
        if (yellowVal <= CoinManager.Instance.coinNum)
        {
            CoinManager.Instance.BuyItem();
            CoinManager.Instance.coinNum -= yellowVal;
            bigYellowPotion.SetActive(false);
            playerMover.conDelay -= 0.25f;
        }
        
    }

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Player");
        playerMover = player.GetComponent<Mover>();
        playerCont = player.GetComponentInChildren<PlayerCtrl>();
        playerAttack = player.GetComponentInChildren<Attacker>().range;
        playerHp = player.GetComponent<HpObject>();
        int.TryParse( bigRedPotionVal.text, out redVal);
        int.TryParse( bigBluePotionVal.text, out blueVal);
        int.TryParse( bigGreenPotionVal.text, out greenVal);
        int.TryParse( bigYellowPotionVal.text, out yellowVal);
    }
}
