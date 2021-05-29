using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

        [SerializeField] Animator StorePanelImageAnim;
        [SerializeField] Animator StorePanelUpLineAnim;
        [SerializeField] Animator StorePanelDownLineAnim;

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
            StorePanelImageAnim.SetBool("isON", true);
            StorePanelUpLineAnim.SetBool("isON", true);
            StorePanelDownLineAnim.SetBool("isON", true);
            for (int i = 0; i < Buttons.Length; i++)
            {
                Buttons[i].interactable = false;
            }
            Invoke("ShowStoreItem", 0.63f);
        }

        public void StoreClickBackButton()
        {
            StoreObject.SetActive(false);
            StorePanelImageAnim.SetBool("isON", false);
            StorePanelUpLineAnim.SetBool("isON", false);
            StorePanelDownLineAnim.SetBool("isON", false);
            Invoke("ExitStore", 0.65f);
        }

        void ExitStore()
        {
            StoreParents.SetActive(false);
            for (int i = 0; i < Buttons.Length; i++)
            {
                Buttons[i].interactable = true;
            }
        }

        void ShowStoreItem()
        {
            StoreObject.SetActive(true);
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