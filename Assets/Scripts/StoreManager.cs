using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    public Button[] Buttons;
    public GameObject StoreParents;
    public GameObject StoreObject;
    [SerializeField]
    GameObject StorePanelImage;
    Animator StorePanelImageAnim;
    [SerializeField]
    GameObject StorePanelUpLine;
    Animator StorePanelUpLineAnim;
    [SerializeField]
    GameObject StorePanelDownLine;
    Animator StorePanelDownLineAnim;
    // Start is called before the first frame update
    void Start()
    {
        StorePanelImageAnim = StorePanelImage.GetComponent<Animator>();
        StorePanelUpLineAnim = StorePanelUpLine.GetComponent<Animator>();
        StorePanelDownLineAnim = StorePanelDownLine.GetComponent<Animator>();
    }

    public void ClickStore()
    {
        StoreParents.SetActive(true);
        StorePanelImageAnim.SetBool("isON", true);
        StorePanelUpLineAnim.SetBool("isON", true);
        StorePanelDownLineAnim.SetBool("isON", true);
        for(int i = 0; i < Buttons.Length; i++)
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

}
