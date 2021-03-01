using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{

    public void ClickPlay()
    {
        Debug.Log("Play!");
        FindObjectOfType<GameManager>().GameStarted = true;
    }

    public void ClickStore()
    {
        Debug.Log("Store!");
        FindObjectOfType<StoreManager>().ClickStore();
}

    public void ClickSetting()
    {
        Debug.Log("Setting!");
        FindObjectOfType<SettingManager>().ClickSetting();
    }

    public void ClickAcade()
    {
        Debug.Log("Acade!");
        FindObjectOfType<AcadeManager>().ClickAcade();
        FindObjectOfType<AcadeManager>().GetComponent<Animator>().SetBool("isClick", true);
    }

}
