using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace DanielLochner.Assets.SimpleScrollSnap {
    public class CheckSelectButton : MonoBehaviour
    {
        [SerializeField] SimpleScrollSnap CharacterScrollSnap;
        [SerializeField] SimpleScrollSnap ObjectScrollSnap;

        public Button CharacterColorSelectButton;
        public Button ObjectColorSelectButton;

        [SerializeField] TextMeshProUGUI CharacterColorSelectButtonText;
        [SerializeField] TextMeshProUGUI ObjectColorSelectButtonText;

        private void Update()
        {
            CharacterColorSelectButton.gameObject.SetActive(StoreManager.CharacterColorList[CharacterScrollSnap.CurrentPanel].ColorNameText != StoreManager.CharacterColor.ColorNameText);
            ObjectColorSelectButton.gameObject.SetActive(StoreManager.InGameObjectColorList[ObjectScrollSnap.CurrentPanel].ColorNameText != StoreManager.InGameObjectColor.ColorNameText);
            CharacterColorSelectButtonText.text = StoreManager.CharacterColorList[CharacterScrollSnap.CurrentPanel].isHaveThisColor ? "선택" : "구매";
            ObjectColorSelectButtonText.text = StoreManager.InGameObjectColorList[ObjectScrollSnap.CurrentPanel].isHaveThisColor ? "선택" : "구매";
        }
    }

}