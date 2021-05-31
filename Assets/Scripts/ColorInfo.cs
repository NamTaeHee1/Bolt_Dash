using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

namespace DanielLochner.Assets.SimpleScrollSnap
{
    public class ColorInfo : MonoBehaviour
    {
        public Color32 CircleColor;
        public string ColorNameText;
        public bool isHaveThisColor = false;
        public bool isSelectThisColor = false;
        public int NecessaryElectronic;
        TextMeshProUGUI ColorText;
        SpriteRenderer CircleSpriteRenderer;
        GameObject Lock;

        private void Awake()
        {
            CircleSpriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
            ColorText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            Lock = transform.GetChild(2).gameObject;
        }

        private void Start()
        {
            CheckThisColor();
            ColorText.faceColor = CircleColor;
            ColorText.outlineColor = CircleColor;
            ColorText.text = ColorNameText;
            ColorText.GetComponent<RectTransform>().sizeDelta = new Vector2(ColorText.text.Length * 60, 100);
            CircleSpriteRenderer.color = CircleColor;
        }

        public void CheckThisColor()
        {
            if (!isSelectThisColor)
                CircleColor.a = 80;
            Lock.SetActive(!isHaveThisColor);
        }

        public void TurnOnOff(bool isTurnOn)
        {
            CircleColor.a = isTurnOn ? (byte)255 : (byte)80;
            ColorText.faceColor = CircleColor;
            ColorText.outlineColor = CircleColor;
            CircleSpriteRenderer.color = CircleColor;
            isSelectThisColor = isTurnOn ? true : false;
        }
    }

}