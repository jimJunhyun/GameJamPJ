using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BossAttackMethod
{
    public AttackRange range;
    public Transform attPos;
    public GameObject warningRange;
}
public class BossAttacker : MonoBehaviour
{
    public List<BossAttackMethod> bossAttacks = new List<BossAttackMethod>();
    public bool attackTrigger;
    BossAttackMethod bossAttack;
    [Tooltip("적들을 위한 공격 대리자. Mover에서 Invoke한다.")]
    public Action attack;
    [SerializeField]
    Animator anim;


    void Attack()
    {
        int a = UnityEngine.Random.Range(0, bossAttacks.Count);
        bossAttack = bossAttacks[a];
        bossAttack.range.transform.position = bossAttack.attPos.position;

        anim.SetInteger("Boss Attacker", a);
        anim.SetBool("Attack", true);
        StartCoroutine(DelayOnOff());
    }

    IEnumerator DelayOnOff()
    {

        if (bossAttack.warningRange != null)
        {
            bossAttack.warningRange.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            bossAttack.warningRange.SetActive(false);
        }

        bossAttack.range.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        bossAttack.range.gameObject.SetActive(false);
    }

    private void Awake()
    {
        attack = Attack;
        foreach (var a in bossAttacks)
        {
            if (a.warningRange != null)
            {
                a.warningRange.SetActive(false);
            }

            a.range.gameObject.SetActive(false);
        }
    }

    private void Update()
    {

        if (attackTrigger)
        {

            attackTrigger = false;
            Attack();

        }
    }
    public void FlaseAttack()
    {
        anim.SetBool("Attack", false);
    }
}

