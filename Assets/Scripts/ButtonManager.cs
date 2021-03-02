using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    Button[] Buttons;
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
        for (int i = 0; i < 4; i++)
            Buttons[i].interactable = false;
        FindObjectOfType<AcadeManager>().ClickAcade();
        Buttons[2].GetComponent<Animator>().SetTrigger("Pressed");
    }

}
