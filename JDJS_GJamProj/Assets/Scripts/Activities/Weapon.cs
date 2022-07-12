using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Weapon : MonoBehaviour
{
    Transform _weapon;
    Quaternion _weaponQua;
    Vector3 _endPos;
    void Start()
    {
        _weapon = transform.Find("Weapon");
        _weaponQua = _weapon.rotation;
        _endPos = _weapon.rotation.eulerAngles - new Vector3(0, 0, 180f);
    }
    public void Attack()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(_weapon.DORotate(_endPos, 0.1f));
        seq.Append(_weapon.DORotate(_weapon.rotation.eulerAngles, 0.05f,RotateMode.WorldAxisAdd));
        seq.OnComplete(() => { _weapon.rotation = _weaponQua; });
    }
}
