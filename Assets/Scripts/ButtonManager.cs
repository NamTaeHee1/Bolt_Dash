using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DanielLochner.Assets.SimpleScrollSnap
{
    public class ButtonManager : MonoBehaviour
    {
        static void ButtonInteractableControl(Button button, bool boolean)
        {
            button.interactable = boolean;
        }

        static void ButtonInteractableControl(Button[] buttons, bool boolean)
        {
            for (int i = 0; i < buttons.Length; i++)
                buttons[i].interactable = boolean;
        }

        static void ButtonAlphaHitTestMinimumThresholdControl(Image button, bool boolean)
        {

        }
    }
}
