using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DanielLochner.Assets.SimpleScrollSnap {
    public class CheckCurrentCharacterColor : MonoBehaviour
    {
        [SerializeField] SimpleScrollSnap CharacterScrollSnap;

        private void Update()
        {
            Debug.Log(CharacterScrollSnap.CurrentPanel);
        }
    }

}