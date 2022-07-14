using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Button Quit;
    public Button Play;
    public Image Panel;
    public Image Boss;
    public Image image;
    float time = 0;
    float ftime = 1f;
    Animator animator;
    public void Fade()
    {
        StartCoroutine(FadeFlow());
    }

    IEnumerator FadeFlow()
    {
        Play.DOPlay();
        Panel.gameObject.SetActive(true);
        Play.gameObject.SetActive(false);
        Quit.gameObject.SetActive(false)    ;
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
        //yield return new WaitForSeconds(3f);
        //animator = GameObject.Find("StartSceneBoss").GetComponent<Animator>();
        //animator.SetBool("isDochak", true);
    }

    // Start is called before the first frame update
    void Awake()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(image.DOColor(new Color(0,0,0,0),1f));
        seq.OnComplete(() =>
        {
            image.gameObject.SetActive(false);
        });

        //MenuPanel.DOAnchorPos(Vector2.zero, 0.25f);
    }

}
