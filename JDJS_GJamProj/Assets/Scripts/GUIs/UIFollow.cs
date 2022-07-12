using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFollow : MonoBehaviour
{
    public Transform target;
    Vector3 posOffset;
	RectTransform rect;

	private void Awake()
	{
		rect = GetComponent<RectTransform>();
		posOffset = rect.anchoredPosition;
	}
	// Update is called once per frame
	void Update()
    {
        if(target.position != transform.position)
		{
            rect.anchoredPosition = target.position + posOffset;
		}
    }
}
