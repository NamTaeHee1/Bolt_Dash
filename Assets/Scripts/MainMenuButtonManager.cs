using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButtonManager : MonoBehaviour
{
    [SerializeField] Button[] Buttons;
    private float AlphaThreshold = 0.1f;

    private void Start()
    {
        for (int i = 0; i < Buttons.Length; i++)
            Buttons[i].GetComponent<Image>().alphaHitTestMinimumThreshold = AlphaThreshold;
    }

    public void ClickPlay()
    {
        Debug.Log("Play!");
        for (int i = 0; i < 4; i++)
            Buttons[i].interactable = false;
        FindObjectOfType<GameManager>().GameStart();
        Buttons[0].GetComponent<Animator>().SetTrigger("Pressed");
    }

    public void ClickStore()
    {
        Debug.Log("Store!");
        FindObjectOfType<DanielLochner.Assets.SimpleScrollSnap.StoreManager>().ClickStore();
        Buttons[1].GetComponent<Animator>().SetTrigger("Pressed");
    }

    public void ClickAcade()
    {
        Debug.Log("Acade!");
        for (int i = 0; i < 4; i++)
            Buttons[i].interactable = false;
        FindObjectOfType<AcadeManager>().ClickAcade();
        Buttons[2].GetComponent<Animator>().SetTrigger("Pressed");
    }

    public void ClickSetting()
    {
        Debug.Log("Setting!");
        FindObjectOfType<SettingManager>().ClickSetting();
        Buttons[3].GetComponent<Animator>().SetTrigger("Pressed");
    }



}
