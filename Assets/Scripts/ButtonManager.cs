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

        }
    }
}
