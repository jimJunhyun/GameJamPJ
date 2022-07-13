using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Effect : MonoBehaviour
{
    [SerializeField] GameObject EffectGameObject;
    [SerializeField] Image Panel;
    [SerializeField] Button menu;
    [SerializeField] Button reStart;

    float time =0f;
    float ftime = 1f;
    void Start()
    {
        StartCoroutine("Fade");
        EffectGameObject.transform.position = transform.position;
        EffectGameObject.SetActive(true);
        menu.gameObject.SetActive(false);
        reStart.gameObject.SetActive(false);
    }
    void Update()
    {
        Instantiate(EffectGameObject);
        Invoke("DDD",0.5f);
        Invoke("Set", 2f);
        
    }
    void DDD()
    {
        EffectGameObject.SetActive(false);
    }
    void Set()
    {
        gameObject.SetActive(false);
        menu.gameObject.SetActive(true);
        reStart.gameObject.SetActive(true);
    }

    IEnumerator Fade()
    {
        yield return new WaitForSeconds(1f);
        Panel.gameObject.SetActive(true);
        Color alpha = Panel.color;
        while (alpha.a <= 1f)
        {
            time += Time.deltaTime / ftime;
            alpha.a = Mathf.Lerp(0, 1, time);
            Panel.color = alpha;
            yield return null;
        }
        yield return null;
    }
    
}
