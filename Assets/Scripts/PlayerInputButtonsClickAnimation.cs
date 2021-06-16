using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInputButtonsClickAnimation : MonoBehaviour
{
    [SerializeField] GameObject[] JumpButtonTiles;
    [SerializeField] GameObject[] RunUpButtonTiles, RunDownButtonTiles;
    [SerializeField] GameObject[] FallButtonTiles;

    bool isFallButtonDown = false, isFallEnd = true;
    bool isJumpButtonDown = false, isJumpEnd = true;
    IEnumerator RunUpCoroutine = null, RunDownCoroutine = null;

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
                isJumpEnd = false;
                float WaitTime = 0.35f;
                for (float i = 0; i < JumpButtonTiles.Length; i++)
                   {
                    JumpButtonTiles[(int)i].SetActive(true);
                    WaitTime -= 0.02f;
                    yield return new WaitForSeconds(WaitTime);
                   }
                for(int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < JumpButtonTiles.Length; j++)
                        JumpButtonTiles[j].SetActive(false);
                    yield return new WaitForSeconds(0.1f);
                    for (int j = 0; j < JumpButtonTiles.Length; j++)
                        JumpButtonTiles[j].SetActive(true);
                    yield return new WaitForSeconds(0.1f);
                }
                for (int j = 0; j < JumpButtonTiles.Length; j++)
                    JumpButtonTiles[j].SetActive(false);
                isJumpEnd = true;
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
                isFallEnd = false;
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
                isFallEnd = true;
                break;
        }
    }

    private void Update()
    {
        if (isFallButtonDown && isFallEnd)
            StartCoroutine(ButtonClick("FallButton"));

        if (isJumpButtonDown && isJumpEnd)
            StartCoroutine(ButtonClick("JumpButton"));
    }

    public void FallButtonDown()
    {
        isFallButtonDown = true;
    }

    public void FallButtonUp()
    {
        isFallButtonDown = false;
    }

    public void JumpButtonDown()
    {
        isJumpButtonDown = true;
    }

    public void JumpButtonUp()
    {
        isJumpButtonDown = false;
        StopAllCoroutines();
    }

}
