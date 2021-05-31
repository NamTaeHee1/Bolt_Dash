using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

namespace DanielLochner.Assets.SimpleScrollSnap {
    public class StoreSelectButtonControl : MonoBehaviour
    {
        [SerializeField] SimpleScrollSnap CharacterScrollSnap;
        [SerializeField] SimpleScrollSnap ObjectScrollSnap;

        public Button CharacterColorSelectButton;
        public Button ObjectColorSelectButton;

        [SerializeField] TextMeshProUGUI CharacterColorSelectButtonText;
        [SerializeField] TextMeshProUGUI ObjectColorSelectButtonText;

        private void Start()
        {
            CheckSelectButtonState();
        }

        public void CheckSelectButtonState()
        {
            CharacterColorSelectButton.gameObject.SetActive(StoreManager.CharacterColorList[CharacterScrollSnap.CurrentPanel].ColorNameText != StoreManager.CharacterColor.ColorNameText);
            ObjectColorSelectButton.gameObject.SetActive(StoreManager.InGameObjectColorList[ObjectScrollSnap.CurrentPanel].ColorNameText != StoreManager.InGameObjectColor.ColorNameText);
            CharacterColorSelectButtonText.text = StoreManager.CharacterColorList[CharacterScrollSnap.CurrentPanel].isHaveThisColor ? "선택" : StoreManager.CharacterColorList[CharacterScrollSnap.CurrentPanel].NecessaryElectronic.ToString();
            ObjectColorSelectButtonText.text = StoreManager.InGameObjectColorList[ObjectScrollSnap.CurrentPanel].isHaveThisColor ? "선택" : StoreManager.InGameObjectColorList[ObjectScrollSnap.CurrentPanel].NecessaryElectronic.ToString();
        }

        public void SelectThisColor()
        {
            string SelectedGameObjectName = EventSystem.current.currentSelectedGameObject.gameObject.name;
            if (SelectedGameObjectName.Equals("CharacterColorSelectButton"))
            {
                ColorInfo CurrentCharacterColorInfo = StoreManager.CharacterColorList[CharacterScrollSnap.CurrentPanel].GetComponent<ColorInfo>();

                if (!CurrentCharacterColorInfo.isHaveThisColor)
                    BuyColor(CurrentCharacterColorInfo);
                else
                {
                    StoreManager.CharacterColor.TurnOnOff(false);
                    StoreManager.CharacterColor = CurrentCharacterColorInfo;
                    StoreManager.CharacterColor.TurnOnOff(true);
                }
            }
            else if (SelectedGameObjectName.Equals("ObjectColorSelectButton"))
            {
                ColorInfo CurrentObjectColorInfo = StoreManager.InGameObjectColorList[ObjectScrollSnap.CurrentPanel].GetComponent<ColorInfo>();

                if (!CurrentObjectColorInfo.isHaveThisColor)
                    BuyColor(CurrentObjectColorInfo);
                else
                {
                    StoreManager.InGameObjectColor.TurnOnOff(false);
                    StoreManager.InGameObjectColor = CurrentObjectColorInfo;
                    StoreManager.InGameObjectColor.TurnOnOff(true);
                }
            }
            CheckSelectButtonState();
        }

        public void BuyColor(ColorInfo SelectedColor)
        {

        }
    }
}