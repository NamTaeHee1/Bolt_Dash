using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DanielLochner.Assets.SimpleScrollSnap {
    public class CheckCurrentCharacterColor : MonoBehaviour
    {
        [SerializeField] SimpleScrollSnap CharacterScrollSnap;
        [SerializeField] Button SelectButton;

        private void Update()
        {
            Debug.Log("ÇöÀç »ö±ò : " + StoreManager.CharacterColorList[CharacterScrollSnap.CurrentPanel].ColorNameText);
        }
    }

}