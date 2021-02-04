using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject StoreImage;
    [SerializeField]
    GameObject StorePanelImage;
    Animator StorePanelImageAnim;
    [SerializeField]
    GameObject StorePanelUpLine;
    Animator StorePanelUpLineAnim;
    [SerializeField]
    GameObject StorePanelDownLine;
    Animator StorePanelDownLineAnim;

    private void Start()
    {
        StorePanelImageAnim = StorePanelImage.GetComponent<Animator>();
        StorePanelUpLineAnim = StorePanelUpLine.GetComponent<Animator>();
        StorePanelDownLineAnim = StorePanelDownLine.GetComponent<Animator>();
    }

    public void ClickPlay()
    {
        Debug.Log("Play!");
    }

    public void ClickStore()
    {
        Debug.Log("Store!");
        StoreImage.SetActive(true);
    }

    public void ClickSetting()
    {
        Debug.Log("Setting!");
    }

    public void ClickAcade()
    {
        Debug.Log("Acade!");
    }
}
