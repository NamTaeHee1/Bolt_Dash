using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject StoreImage;

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
