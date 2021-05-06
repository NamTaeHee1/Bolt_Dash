using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DanielLochner.Assets.SimpleScrollSnap {
    public class CheckCurrentCharacterColor : MonoBehaviour
    {
        [SerializeField] SimpleScrollSnap CharacterScrollSnap;
        [SerializeField] Button SelectButton;

        public void Update() 
        {
            SelectButton.gameObject.SetActive(StoreManager.CharacterColorList[CharacterScrollSnap.CurrentPanel].ColorNameText != StoreManager.CharacterColor.ColorNameText);
        }
    }

}