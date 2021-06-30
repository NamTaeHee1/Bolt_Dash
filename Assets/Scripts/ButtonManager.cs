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
        for (int i = 0; i < buttons.Length; i++)
            buttons[i].interactable = boolean;
    }

    public static void ButtonAlphaHitTestMinimumThresholdControl(Image buttonImage)
    {
        buttonImage.alphaHitTestMinimumThreshold = 0.1f;
}

    public static void ButtonAlphaHitTestMinimumThresholdControl(Image[] buttonImages)
    {
        for (int i = 0; i < buttonImages.Length; i++)
            buttonImages[i].alphaHitTestMinimumThreshold = 0.1f;
    }
}