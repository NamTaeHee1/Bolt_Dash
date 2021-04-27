using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputButtonsClickAnimation : MonoBehaviour
{
    [SerializeField]
    GameObject[] JumpButtonTiles;
    [SerializeField]
    GameObject[] RunUpButtonTiles, RunDownButtonTiles;
    [SerializeField]
    GameObject[] FallButtonTiles;

    bool isButtonDown = false;
    bool isEnd = true;
    IEnumerator RunUpCoroutine = null, RunDownCoroutine = null;
    public void JumpButtonClick()
    {
        StopAllCoroutines();
        for (int i = 0; i < JumpButtonTiles.Length; i++)
            JumpButtonTiles[i].SetActive(false);
        Debug.Log("ClickJump!!");
        StartCoroutine(ButtonClick("JumpButton"));
    }

    public void RunUpButtonClick()
    {
        if (RunUpCoroutine != null)
        {
            StopCoroutine(RunUpCoroutine);
            for (int i = 0; i < RunUpButtonTiles.Length; i++)
                RunUpButtonTiles[i].SetActive(false);
        }

        RunUpCoroutine = ButtonClick("RunUpButton");
        StartCoroutine(RunUpCoroutine);
    }

    public void RunDownButtonClick()
    {
        if (RunDownCoroutine != null)
        {
            StopCoroutine(RunDownCoroutine);
            for (int i = 0; i < RunDownButtonTiles.Length; i++)
                RunDownButtonTiles[i].SetActive(false);
        }

        RunDownCoroutine = ButtonClick("RunDownButton");
        StartCoroutine(RunDownCoroutine);
    }

    IEnumerator ButtonClick(string ButtonName)
    {
        switch(ButtonName)
        {
            case "JumpButton":
                for(int i = 3; i < JumpButtonTiles.Length; i++)
                    {
                    JumpButtonTiles[i].SetActive(true);
                    JumpButtonTiles[i - 1].SetActive(true);
                    JumpButtonTiles[i - 2].SetActive(true);
                    JumpButtonTiles[i - 3].SetActive(true);
                    yield return new WaitForSeconds(0.095f);
                    JumpButtonTiles[i].SetActive(false);
                    JumpButtonTiles[i -1].SetActive(false);
                    JumpButtonTiles[i - 2].SetActive(false);
                    JumpButtonTiles[i - 3].SetActive(false);
                    }
                break;
            case "RunUpButton":
                for(int i = 3; i < RunUpButtonTiles.Length; i++)
                    {
                    RunUpButtonTiles[i].SetActive(true);
                    RunUpButtonTiles[i - 1].SetActive(true);
                    RunUpButtonTiles[i - 2].SetActive(true);
                    RunUpButtonTiles[i - 3].SetActive(true);
                    yield return new WaitForSeconds(0.095f);
                    RunUpButtonTiles[i].SetActive(false);
                    RunUpButtonTiles[i - 1].SetActive(false);
                    RunUpButtonTiles[i - 2].SetActive(false);
                    RunUpButtonTiles[i - 3].SetActive(false);
                    }
                break;
            case "RunDownButton":
                for(int i = RunDownButtonTiles.Length - 4; i > -1; i--)
                    {
                    RunDownButtonTiles[i].SetActive(true);
                    RunDownButtonTiles[i + 1].SetActive(true);
                    RunDownButtonTiles[i + 2].SetActive(true);
                    RunDownButtonTiles[i + 3].SetActive(true);
                    yield return new WaitForSeconds(0.095f);
                    RunDownButtonTiles[i].SetActive(false);
                    RunDownButtonTiles[i + 1].SetActive(false);
                    RunDownButtonTiles[i + 2].SetActive(false);
                    RunDownButtonTiles[i + 3].SetActive(false);
                }
                break;
            case "FallButton":
                isEnd = false;
                    for (int i = FallButtonTiles.Length - 4; i > -1; i--)
                    {
                        FallButtonTiles[i].SetActive(true);
                        FallButtonTiles[i + 1].SetActive(true);
                        FallButtonTiles[i + 2].SetActive(true);
                        FallButtonTiles[i + 3].SetActive(true);
                        yield return new WaitForSeconds(0.095f);
                        FallButtonTiles[i].SetActive(false);
                        FallButtonTiles[i + 1].SetActive(false);
                        FallButtonTiles[i + 2].SetActive(false);
                        FallButtonTiles[i + 3].SetActive(false);
                    }
                yield return new WaitForSeconds(0.1f);
                isEnd = true;
                break;
        }
    }

    private void Update()
    {
        if (isButtonDown && isEnd)
            StartCoroutine(ButtonClick("FallButton"));
    }

    public void ButtonDown()
    {
        isButtonDown = true;
    }

    public void ButtonUp()
    {
        isButtonDown = false;
    }

}
