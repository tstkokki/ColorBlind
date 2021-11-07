using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_TitleFloat : MonoBehaviour
{
    private RectTransform rect;
    public float floatSpeed;
    public float floatAmount;
    Vector2 startPos;
    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        startPos = rect.anchoredPosition;
    }

    // Update is called once per frame
    void Update()
    {
        rect.anchoredPosition = new Vector2(startPos.x, startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatAmount);
    }
}
