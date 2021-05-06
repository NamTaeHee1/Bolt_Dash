using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorInfo : MonoBehaviour
{
    public Color32 CircleColor;
    public string ColorNameText;
    public bool isHaveThisColor = false;
    TextMeshProUGUI ColorText;
    SpriteRenderer CircleSpriteRenderer;

    private void Awake()
    {
        ColorText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        CircleSpriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        CheckHaveThisColor();
        ColorText.faceColor = CircleColor;
        ColorText.outlineColor = CircleColor;
        ColorText.text = ColorNameText;
        ColorText.GetComponent<RectTransform>().sizeDelta = new Vector2(ColorText.text.Length * 60, 100);
        CircleSpriteRenderer.color = CircleColor;
    }

    void CheckHaveThisColor()
    {
        if (!isHaveThisColor)
            CircleColor.a = 80;
    }
}
