using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField] RectTransform MenuPanel;
    [SerializeField] RectTransform Setting;
    [SerializeField] RectTransform ShopPanel;

    // Start is called before the first frame update
    void Start()
    {
        MenuPanel.DOAnchorPos(Vector2.zero, 0.25f);
    }

    public void SettingButton()
    {
        MenuPanel.DOAnchorPos(new Vector2(-1920, 0), 0.25f);
        Setting.DOAnchorPos(new Vector2(0, -459), 0.25f);
    }

    public void SettingCloseOnClick()
    {
        MenuPanel.DOAnchorPos(new Vector2(0, 0), 0.25f);
        Setting.DOAnchorPos(new Vector2(1920, -459), 0.25f);
    }

    public void ShopCloseOnClick()
    {
        MenuPanel.DOAnchorPos(new Vector2(0, 0), 0.25f);
        ShopPanel.DOAnchorPos(new Vector2(-1920, -1258.9f), 0.25f);
    }

    public void ShopButton()
    {
        MenuPanel.DOAnchorPos(new Vector2(1920, 0), 0.25f);
        ShopPanel.DOAnchorPos(new Vector2(0, -1258.9f), 0.25f);
    }

}
