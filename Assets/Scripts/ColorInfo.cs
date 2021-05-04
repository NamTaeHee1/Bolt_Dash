using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorInfo : MonoBehaviour
{
    [SerializeField] Color32 CircleColor;
    [SerializeField] string ColorNameText;
    TextMeshProUGUI ColorText;
    SpriteRenderer CircleSpriteRenderer;

    private void Awake()
    {
        ColorText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        CircleSpriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        ColorText.faceColor = CircleColor;
        ColorText.outlineColor = CircleColor;
        ColorText.text = ColorNameText;
        ColorText.GetComponent<RectTransform>().sizeDelta = new Vector2(ColorText.text.Length * 60, 100);
        CircleSpriteRenderer.color = CircleColor;
    }
}
