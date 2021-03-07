using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickAnimation : MonoBehaviour
{
    [SerializeField]
    GameObject[] JumpButtonTiles;
    [SerializeField]
    GameObject[] RunButtonTiles;
    [SerializeField]
    GameObject[] FallButtonTiles;
    public void JumpButtonClick()
    {
        StartCoroutine(ButtonClick("JumpButton"));
    }

    public void RunButtonClick()
    {
        StartCoroutine(ButtonClick("RunButton"));
    }

    public void FallButtonClick()
    {
        StartCoroutine(ButtonClick("FallButton"));
    }

    IEnumerator ButtonClick(string ButtonName)
    {
        switch(ButtonName)
        {
            case "JumpButton":
                break;
            case "RunButton":
                break;
            case "FallButton":
                yield return new WaitForSeconds(3.0f);
                break;
        }
    }
}
