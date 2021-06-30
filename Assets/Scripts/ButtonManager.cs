using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public static void ButtonInteractableControl(Button button, bool boolean)
    {
        button.interactable = boolean;
    }

    public static void ButtonInteractableControl(Button[] buttons, bool boolean)
    {
        Debug.Log(buttons.GetType());
        for (int i = 0; i < buttons.Length; i++)
            buttons[i].interactable = boolean;

    }

    static void ButtonAlphaHitTestMinimumThresholdControl(Image button, bool boolean)
    {

    }
}