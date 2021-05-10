using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DanielLochner.Assets.SimpleScrollSnap {
    public class CheckSelectButton : MonoBehaviour
    {
        [SerializeField] SimpleScrollSnap CharacterScrollSnap;
        public Button SelectButton;

        public void CheckButtonUpdate()
        {
            SelectButton.gameObject.SetActive(StoreManager.CharacterColorList[CharacterScrollSnap.CurrentPanel].ColorNameText != StoreManager.CharacterColor.ColorNameText);
        }
    }

}