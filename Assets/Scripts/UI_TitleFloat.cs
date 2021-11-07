using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_TitleFloat : MonoBehaviour
{
    private RectTransform rect;
    public float floatSpeed;
    public float floatAmount;
    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, rect.anchoredPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatAmount);
    }
}
