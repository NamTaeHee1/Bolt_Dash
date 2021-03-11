using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSetting : MonoBehaviour
{
    private void Start()
    {
        Screen.SetResolution(Screen.height * 16 / 9, Screen.height, true);
    }
}
