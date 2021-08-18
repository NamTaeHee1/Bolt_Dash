using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputButtonStateControl : MonoBehaviour
{
    public static InputButtonType ButtonState;

    public void SetButtonState(int TypeIndex) // Jump = 0, Run = 1, Fall = 2
    {
        ButtonState = (InputButtonType)TypeIndex;
    }

    public InputButtonType GetButtonState()
    {
        return ButtonState;
    }

}
