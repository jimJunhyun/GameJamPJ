using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimActivate : MonoBehaviour
{
    public List<Animator> weapons = new List<Animator>();
    public string useTriggerName = "Use";
    Attacker holder;

    int currentHold;
    // Start is called before the first frame update
    void Awake()
    {
        holder = GetComponentInParent<Attacker>();
        currentHold = holder.attackNo;
        
		for (int i = 0; i < weapons.Count; i++)
		{
            weapons[i].gameObject.SetActive(false);
		}
        weapons[currentHold].gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
		if (holder.attackTrigger)
		{
            weapons[currentHold].SetTrigger(useTriggerName);
		}
        if(holder.attackNo != currentHold)
		{
            weapons[currentHold].gameObject.SetActive(false);
            currentHold = holder.attackNo;
            weapons[currentHold].gameObject.SetActive(true);
		}
    }
}
