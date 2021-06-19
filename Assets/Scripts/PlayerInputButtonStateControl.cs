using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputButtonStateControl : MonoBehaviour
{
    public enum ButtonType { JUMP, RUN, FALL };
    public ButtonType ButtonState;
    [SerializeField] GameObject[] Buttons;
    public string ButtonName = "";

}
