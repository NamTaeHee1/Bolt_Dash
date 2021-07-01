using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButtonManager : MonoBehaviour
{
    [SerializeField] Button[] MainButtons;
    [SerializeField] Image[] MainButtonImages;

    private void Start()
    {
        ButtonManager.ButtonAlphaHitTestMinimumThresholdControl(MainButtonImages);
    }

    public void ClickPlay()
    {
        Debug.Log("Play!");
        ButtonManager.ButtonInteractableControl(MainButtons, false);
        FindObjectOfType<GameManager>().GameStart();
    }

    public void ClickStore()
    {
        Debug.Log("Store!");
        ButtonManager.ButtonInteractableControl(MainButtons, false);
        FindObjectOfType<DanielLochner.Assets.SimpleScrollSnap.StoreManager>().ClickStore();
    }

    public void ClickAcade()
    {
        Debug.Log("Acade!");
        ButtonManager.ButtonInteractableControl(MainButtons, false);
        FindObjectOfType<AcadeManager>().ClickAcade();
    }

    public void ClickSetting()
    {
        Debug.Log("Setting!");
        ButtonManager.ButtonInteractableControl(MainButtons, false);
        FindObjectOfType<SettingManager>().ClickSetting();
    }
}
