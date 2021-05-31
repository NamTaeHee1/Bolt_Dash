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
            if (EventSystem.current.currentSelectedGameObject.name.Equals("CharacterColorSelectButton"))
            {
                StoreManager.CharacterColor.TurnOnOff(false);
                for (int i = 0; i < StoreManager.CharacterColorList.Count; i++)
                    Debug.Log(StoreManager.CharacterColorList[i].ColorNameText + " ");
                StoreManager.CharacterColor = StoreManager.CharacterColorList[CharacterScrollSnap.CurrentPanel].GetComponent<ColorInfo>();
                StoreManager.CharacterColor.TurnOnOff(true);
            }
            else if (EventSystem.current.currentSelectedGameObject.name.Equals("ObjectColorSelectButton"))
            {
                StoreManager.InGameObjectColor.TurnOnOff(false);
                StoreManager.InGameObjectColor = StoreManager.InGameObjectColorList[ObjectScrollSnap.CurrentPanel].GetComponent<ColorInfo>();
                StoreManager.InGameObjectColor.TurnOnOff(true);
            }
            CheckSelectButtonState();
        }
    }

}