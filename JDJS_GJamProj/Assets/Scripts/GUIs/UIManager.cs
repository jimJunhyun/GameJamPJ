using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] RectTransform MenuPanel;
    [SerializeField] RectTransform Setting;
    [SerializeField] RectTransform ShopPanel;
    public Image Panel;
    float time = 0;
    float ftime = 1f;
    public void Fade()
    {
        StartCoroutine(FadeFlow());
    }

    IEnumerator FadeFlow()
    {
        Panel.gameObject.SetActive(true);
        Color alpha = Panel.color;
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / ftime;
            alpha.a = Mathf.Lerp(0, 1, time);
            Panel.color = alpha;
            yield return null;
        }
        yield return null;
        SceneManager.LoadScene("Play");

    }

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
