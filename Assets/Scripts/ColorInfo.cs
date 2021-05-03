using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColorInfo : MonoBehaviour
{
    [SerializeField] Color32 CircleColor;
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
        CircleSpriteRenderer.color = CircleColor;
    }
}
