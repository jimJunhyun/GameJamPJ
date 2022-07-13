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
    
    GameObject player;
    Mover playerMover;
    AttackRange playerAttack;
    PlayerCtrl playerCont;
    HpObject playerHp;
    
    public void RedBigPotionClick()
    {
        bigRedPotion.SetActive(false);
        playerAttack.damage += 1;
    }
    public void BlueBigPotionClick()
    {
        bigBluePotion.SetActive(false);
        playerCont.cooltime -= 0.25f;
    }
    public void GreenBigPotionClick()
    {
        bigGreenPotion.SetActive(false);
        playerHp.maxHp += 2;
    }
    public void YellowBigPotionClick()
    {
        bigYellowPotion.SetActive(false);
        playerMover.conDelay -= 0.25f;
    }

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Player");
        playerMover = player.GetComponent<Mover>();
        playerCont = player.GetComponentInChildren<PlayerCtrl>();
        playerAttack = player.GetComponentInChildren<Attacker>().range;
        playerHp = player.GetComponent<HpObject>();
    }
}
