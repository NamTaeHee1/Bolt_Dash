using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace DanielLochner.Assets.SimpleScrollSnap
{
    public class StoreManager : MonoBehaviour
    {
        public Button[] Buttons;
        public GameObject StoreParents;
        public GameObject StoreObject;
        public GameObject CharacterColorContent;
        public GameObject InGameObjectColorContent;

        [SerializeField] GameObject StorePanelImage;
        [SerializeField] GameObject StorePanelUpLine;
        [SerializeField] GameObject StorePanelDownLine;

        [SerializeField] Animator StoreAnim;

        [SerializeField] SimpleScrollSnap CharacterScrollSnap;
        [SerializeField] SimpleScrollSnap ObjectScrollSnap;

        static public List<ColorInfo> CharacterColorList = new List<ColorInfo>();
        static public List<ColorInfo> InGameObjectColorList = new List<ColorInfo>();
        static public ColorInfo CharacterColor;
        static public ColorInfo InGameObjectColor;

        private void Awake() => ColorListUpdate();

        void Start()
        {
            CharacterColor = CharacterColorContent.transform.GetChild(0).GetComponent<ColorInfo>();
            InGameObjectColor = InGameObjectColorContent.transform.GetChild(0).GetComponent<ColorInfo>();
        }

        public void ClickStore()
        {
            StoreParents.SetActive(true);
            StoreAnim.Play("StoreON", -1, 0f);
            for (int i = 0; i < Buttons.Length; i++)
            {
                Buttons[i].interactable = false;
            }
        }

        public void StoreClickBackButton()
        {
            StoreObject.SetActive(false);
            StoreAnim.Play("StoreOFF", -1, 0f);
            StartCoroutine(ExitStore());
        }

        IEnumerator ExitStore()
        {
            StoreParents.SetActive(false);
            for (int i = 0; i < Buttons.Length; i++)
            {
                Buttons[i].interactable = true;
            }
            yield return new WaitForSeconds(0.65f);
        }

        public void ColorListUpdate()
        {
            CharacterColorList.Clear();
            InGameObjectColorList.Clear();
            for (int i = 0; i < CharacterColorContent.transform.childCount; i++)
                CharacterColorList.Add(CharacterColorContent.transform.GetChild(i).GetComponent<ColorInfo>());
            for (int i = 0; i < InGameObjectColorContent.transform.childCount; i++)
                InGameObjectColorList.Add(InGameObjectColorContent.transform.GetChild(i).GetComponent<ColorInfo>());
            Debug.Log("¼ö : " + CharacterColorContent.transform.childCount);
            Debug.Log("¼ö : " + InGameObjectColorContent.transform.childCount);
        }
    }
}