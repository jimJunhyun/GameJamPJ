using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CoinManager.Instance.GetCoins();
            CoinManager.Instance.coinNum +=  value;
            Destroy(gameObject);
        }
    }

}
