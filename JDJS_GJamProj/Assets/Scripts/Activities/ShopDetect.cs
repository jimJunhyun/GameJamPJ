using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopDetect : MonoBehaviour
{
    public GameObject shopPanel;
	public bool shopping = false;
    Collider2D coll;

	// Update is called once per frame
	void FixedUpdate()
    {
        if((coll = Physics2D.OverlapBox(transform.position, Vector2.one * 0.5f, 0)) && coll.CompareTag("Shop"))
		{
			shopping = true;
            shopPanel.SetActive(true);
		}
		else
		{
			Debug.Log("!");
			shopping = false;
			shopPanel.SetActive(false);
		}
    }
}
