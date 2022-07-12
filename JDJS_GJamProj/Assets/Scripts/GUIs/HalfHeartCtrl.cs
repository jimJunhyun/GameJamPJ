using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HalfHeartCtrl : MonoBehaviour
{
    public Slider hpBar;
    RectTransform rect;
    Image image;
    // Start is called before the first frame update
    void Awake()
    {
        rect = GetComponent<RectTransform>();
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hpBar.value % 2 != 0)
		{
            image.enabled = true;
            rect.anchoredPosition = new Vector2(hpBar.value * 2, 0);
        }
		else
		{
            image.enabled = false;
		}
    }
}
