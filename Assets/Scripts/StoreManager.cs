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
        [SerializeField]    GameObject StorePanelImage;
        [SerializeField]    GameObject StorePanelUpLine;
        [SerializeField]    GameObject StorePanelDownLine;

        Animator StorePanelImageAnim;
        Animator StorePanelUpLineAnim;
        Animator StorePanelDownLineAnim;

        static public List<ColorInfo> CharacterColorList = new List<ColorInfo>();
        static public List<Color32> InGameObjectColorList = new List<Color32>();
        static public Color32 CharacterColor;
        static public Color32 InGameObjectColor;

        // Start is called before the first frame update
        void Awake()
        {
            Debug.Log(CharacterColor);
            StorePanelImageAnim = StorePanelImage.GetComponent<Animator>();
            StorePanelUpLineAnim = StorePanelUpLine.GetComponent<Animator>();
            StorePanelDownLineAnim = StorePanelDownLine.GetComponent<Animator>();
            ColorListUpdate();
        }

        void Update()
        {
            for (int i = 0; i < CharacterColorList.Count; i++)
                Debug.Log(string.Format("{0}¹ø¤Š »ö±ò : {1}", i, CharacterColorList[i].ColorNameText));
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
            for (int i = 0; i < CharacterColorContent.transform.childCount; i++)
                CharacterColorList.Add(CharacterColorContent.transform.GetChild(i).GetComponent<ColorInfo>());
            Debug.Log("¼ö : " + CharacterColorContent.transform.childCount);
        }
    }
}