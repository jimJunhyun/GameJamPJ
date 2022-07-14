using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;

public class Tutorial : MonoBehaviour
{
    [SerializeField] Text Text;
    [SerializeField] Text ClearText;
    [SerializeField] List<Button> weaponList = new List<Button>();
    [SerializeField] Mover playerMover;
    [SerializeField] Attacker playerAttacker;

    public UnityEvent OnComplete;

    bool check;
    bool space = false;
    bool selectWeapon = false;
    void Awake()
    {
        StartCoroutine(TextDelay());
    }
    IEnumerator TextDelay()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(Text.DOText("�� ������ �ڵ����� �����Դϴ�.", 2f));
        yield return new WaitForSeconds(3f);
        playerMover.enabled = true;
        yield return new WaitForSeconds(1f);
        Text.text = "";
        seq.Append(Text.DOText("Space�� ���� ������ ȸ���� ���ʽÿ�.", 1f));
        space = true;
        yield return new WaitUntil(() => check);
        check = false;
        ClearText.gameObject.SetActive(true);
        seq.Append(ClearText.transform.DOScale(10f, 0.2f));
        yield return new WaitForSeconds(0.2f);
        seq.Append(ClearText.transform.DOScale(8f, 0.1f));
        yield return new WaitForSeconds(1f);
        ClearText.gameObject.SetActive(false);
        playerMover.enabled = false;
        yield return new WaitForSeconds(0.5f);
        Text.text = "";
        seq.Append(Text.DOText("���⸦ ������ ���ʽÿ�.", 1f));
        
        yield return new WaitForSeconds(1f);
        foreach (Button weapon in weaponList)
        {
            weapon.gameObject.SetActive(true);
            weapon.transform.DOScale(1f, 0.5f);
        }
        yield return new WaitUntil(() => check);
        ClearText.gameObject.SetActive(true);
        seq.Append(ClearText.transform.DOScale(10f, 0.2f));
        yield return new WaitForSeconds(0.2f);
        seq.Append(ClearText.transform.DOScale(8f, 0.1f));
        foreach (Button weapon in weaponList)
        {
            weapon.transform.DOScale(0.1f, 0.5f);
            weapon.gameObject.SetActive(false);
        }
        selectWeapon = true;
        check = false;
        yield return new WaitForSeconds(1f);
        ClearText.gameObject.SetActive(false);
        Text.text = "";
        seq.Append(Text.DOText("��Ŭ���� �� ����� ������ �غ��ʽÿ�.", 1f));
        playerAttacker.enabled = true;
        yield return new WaitUntil(() => check);
        ClearText.gameObject.SetActive(true);
        seq.Append(ClearText.transform.DOScale(10f, 0.2f));
        yield return new WaitForSeconds(0.2f);
        seq.Append(ClearText.transform.DOScale(8f, 0.1f));

        yield return new WaitForSeconds(0.3f);

        OnComplete.Invoke();
    }
    private void Update()
    {
        if (space == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                space = false;
                check = true;
            }
        }
        if (selectWeapon == true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                selectWeapon = false;
                check = true;
            }
        }
    }
    public void ButtonTrue(int weaponNum)
    {
        check = true;
        playerAttacker.attackNo = weaponNum;
    }
}
