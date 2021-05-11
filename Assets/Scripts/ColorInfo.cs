using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace DanielLochner.Assets.SimpleScrollSnap
{
    public class ColorInfo : MonoBehaviour
    {
        public Color32 CircleColor;
        public string ColorNameText;
        public bool isHaveThisColor = false;
        public bool isSelectThisColor = false;
        TextMeshProUGUI ColorText;
        SpriteRenderer CircleSpriteRenderer;
        [SerializeField] TextMeshProUGUI ButtonText;
        [SerializeField] SimpleScrollSnap CharacterSimpleScroll;

        private void Awake()
        {
            ColorText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            CircleSpriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
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

        void CheckThisColor()
        {
            if (!isSelectThisColor)
                CircleColor.a = 80;
            ButtonText.text = !isHaveThisColor ? "구매" : "선택";
        }

        public void SelectThisColor()
        {
            Debug.Log("클릭");
            StoreManager.CharacterColor.TurnOnOff(false);
            StoreManager.CharacterColor = StoreManager.CharacterColorList[CharacterSimpleScroll.CurrentPanel].GetComponent<ColorInfo>();
            StoreManager.CharacterColor.TurnOnOff(true);
        }

        void TurnOnOff(bool isTurnOn)
        {
            Debug.Log(this.ColorNameText + " " + isTurnOn);
            CircleColor.a = isTurnOn ? (byte)255 : (byte)80;
            ColorText.faceColor = CircleColor;
            ColorText.outlineColor = CircleColor;
            CircleSpriteRenderer.color = CircleColor;
            isSelectThisColor = isTurnOn ? true : false;
        }
    }

}