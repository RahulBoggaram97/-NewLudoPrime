using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scroll : MonoBehaviour
{
	static ScrollRect scrollRect;

	public Image[] imagaeArray;


	public RectTransform content;

	void Start()
	{
		scrollRect = GetComponent<ScrollRect>();
		scrollRect.onValueChanged.AddListener(ListenerMethod);
		imagaeArray[0].color = Color.white;
		imagaeArray[1].color = Color.black;
		imagaeArray[2].color = Color.black;

		content.anchoredPosition = new Vector2(3000, 0);

	}

    private void Update()
    {
		snapimage();
    }

    private void snapimage()
    {
       if(content.anchoredPosition.x > 1500 && content.anchoredPosition.x < 2000)
        {
			content.anchoredPosition = new Vector2(3000, 0);
        }
		if (content.anchoredPosition.x < 1500 && content.anchoredPosition.x > 1000 && content.anchoredPosition.x > -1500 && content.anchoredPosition.x < -1000)
		{
			content.anchoredPosition = new Vector2(0, 0);
		}
		if (content.anchoredPosition.x < -1500)
		{
			content.anchoredPosition = new Vector2(-3000, 0);
		}
	}

    public void ListenerMethod(Vector2 value)
	{
		Debug.Log("ListenerMethod: " + value);
		if(value.x < 0.4f)
        {
			imagaeArray[0].color = Color.white;
			imagaeArray[1].color = Color.black;
			imagaeArray[2].color = Color.black;
			
		}
		
		if (value.x > 0.4f && value.x < 0.8f)
		{
			imagaeArray[0].color = Color.black;
			imagaeArray[1].color = Color.white;
			imagaeArray[2].color = Color.black;
			
        }
		if ( value.x > 0.8f)
		{
			imagaeArray[0].color = Color.black;
			imagaeArray[1].color = Color.black;
			imagaeArray[2].color = Color.white;
			
        }


		
	}
}
