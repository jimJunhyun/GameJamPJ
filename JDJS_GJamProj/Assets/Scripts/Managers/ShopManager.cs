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
    [SerializeField] GameObject smallRedPotion;
    [SerializeField] GameObject smallBluePotion;
    [SerializeField] GameObject smallGreenPotion;
    [SerializeField] GameObject smallYellowPotion;

    [SerializeField] Text bigRedPotionVal;
    [SerializeField] Text bigBluePotionVal;
    [SerializeField] Text bigGreenPotionVal;
    [SerializeField] Text bigYellowPotionVal;
    [SerializeField] Text smallRedPotionVal;
    [SerializeField] Text smallBluePotionVal;
    [SerializeField] Text smallGreenPotionVal;
    [SerializeField] Text smallYellowPotionVal;

    [SerializeField] Text ATK;
    [SerializeField] Text ASPD;
    [SerializeField] Text SPD;

    int attackNumber;
    int redVal;
    int blueVal;
    int greenVal;
    int yellowVal;
    int SredVal;
    int SblueVal;
    int SgreenVal;
    int SyellowVal;

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
            
			for (int i = 0; i < playerAttack.Count; i++)
			{
                playerAttack[i].damage += 2;
            }
            ATK.text = "ATK : " + playerAttack[attackNumber].damage;
            bigRedPotion.SetActive(false);
        }
        
    }
    public void BlueBigPotionClick()
    {
        if (blueVal <= CoinManager.Instance.coinNum)
        {
            CoinManager.Instance.BuyItem();
            CoinManager.Instance.coinNum -= blueVal;
            playerCont.cooltime -= 0.25f;
            ASPD.text = "ASPD : " + playerCont.cooltime;
            bigBluePotion.SetActive(false);

        }

    }
    public void GreenBigPotionClick()
    {
        if (greenVal <= CoinManager.Instance.coinNum)
        {
            CoinManager.Instance.BuyItem();
            CoinManager.Instance.coinNum -= greenVal;
            playerHp.HpIncrease(5);
            bigGreenPotion.SetActive(false);
        }
        
    }
    public void YellowBigPotionClick()
    {
        if (yellowVal <= CoinManager.Instance.coinNum)
        {
            CoinManager.Instance.BuyItem();
            CoinManager.Instance.coinNum -= yellowVal;
            playerMover.conDelay -= 0.1f;
            SPD.text = "SPD : " + playerMover.conDelay;
            bigYellowPotion.SetActive(false);
            
        }
        
    }
    public void RedSmallPotionClick()
    {
        if (SredVal <= CoinManager.Instance.coinNum)
        {
            CoinManager.Instance.coinNum -= SredVal;
            CoinManager.Instance.BuyItem();
            for (int i = 0; i < playerAttack.Count; i++)
            {
                playerAttack[i].damage += 1;
            }
            ATK.text = "ATK : " + playerAttack[attackNumber].damage;
            smallRedPotion.SetActive(false);

        }

    }
    public void BlueSmallPotionClick()
    {
        if (SblueVal <= CoinManager.Instance.coinNum)
        {
            CoinManager.Instance.coinNum -= SblueVal;
            CoinManager.Instance.BuyItem();
            playerCont.cooltime -= 0.25f;
            ASPD.text = "ASPD : " + playerCont.cooltime;
            smallBluePotion.SetActive(false);
        }

    }
    public void GreenSmallPotionClick()
    {
        if (SgreenVal <= CoinManager.Instance.coinNum)
        {
            CoinManager.Instance.BuyItem();
            CoinManager.Instance.coinNum -= SgreenVal;
            playerHp.HpIncrease(3);
            smallGreenPotion.SetActive(false);
        }

    }
    public void YellowSmallPotionClick()
    {
        if (SyellowVal <= CoinManager.Instance.coinNum)
        {
            CoinManager.Instance.coinNum -= SyellowVal;
            CoinManager.Instance.BuyItem();
            playerMover.conDelay -= 0.05f;
            SPD.text = "SPD : " + playerMover.conDelay;
            smallYellowPotion.SetActive(false);
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
        attackNumber = player.GetComponentInChildren<Attacker>().attackNo;
        int.TryParse( bigRedPotionVal.text, out redVal);
        int.TryParse( bigBluePotionVal.text, out blueVal);
        int.TryParse( bigGreenPotionVal.text, out greenVal);
        int.TryParse( bigYellowPotionVal.text, out yellowVal);
        int.TryParse(smallRedPotionVal.text, out SredVal);
        int.TryParse(smallBluePotionVal.text, out SblueVal);
        int.TryParse(smallGreenPotionVal.text, out SgreenVal);
        int.TryParse(smallYellowPotionVal.text, out SyellowVal);
        ATK.text = "ATK : " + playerAttack[attackNumber].damage;
        ASPD.text = "ASPD : " + playerCont.cooltime;
        SPD.text = "SPD : " + playerMover.conDelay;
    }
}
