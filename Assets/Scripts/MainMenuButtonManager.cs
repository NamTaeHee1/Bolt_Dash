using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButtonManager : MonoBehaviour
{
    [SerializeField] Button[] MainButtons;
    private float AlphaThreshold = 0.1f;

    private void Start()
    {
        for (int i = 0; i < MainButtons.Length; i++)
            MainButtons[i].GetComponent<Image>().alphaHitTestMinimumThreshold = AlphaThreshold;
    }

    public void ClickPlay()
    {
        Debug.Log("Play!");
        for (int i = 0; i < 4; i++)
            MainButtons[i].interactable = false;
        FindObjectOfType<GameManager>().GameStart();
        MainButtons[0].GetComponent<Animator>().SetTrigger("Pressed");
    }

    public void ClickStore()
    {
        Debug.Log("Store!");
        FindObjectOfType<DanielLochner.Assets.SimpleScrollSnap.StoreManager>().ClickStore();
        MainButtons[1].GetComponent<Animator>().SetTrigger("Pressed");
    }

    public void ClickAcade()
    {
        Debug.Log("Acade!");
        for (int i = 0; i < 4; i++)
            MainButtons[i].interactable = false;
        FindObjectOfType<AcadeManager>().ClickAcade();
        MainButtons[2].GetComponent<Animator>().SetTrigger("Pressed");
    }

    public void ClickSetting()
    {
        Debug.Log("Setting!");
        FindObjectOfType<SettingManager>().ClickSetting();
        MainButtons[3].GetComponent<Animator>().SetTrigger("Pressed");
    }



}
