using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputButtonStateControl : MonoBehaviour
{
    public enum ButtonType { JUMP =  0, RUN, FALL };
    public static ButtonType ButtonState;

    public void SetButtonState(int TypeIndex) // Jump = 0, Run = 1, Fall = 2
    {
        ButtonState = (ButtonType)TypeIndex;
    }

}
