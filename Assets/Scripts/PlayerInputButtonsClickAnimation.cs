using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DanielLochner.Assets.SimpleScrollSnap
{
    public class PlayerInputButtonsClickAnimation : MonoBehaviour
    {
        [SerializeField] GameObject[] JumpButtonTiles;
        [SerializeField] GameObject[] JumpYellowBoxParts;
        [SerializeField] GameObject[] RunUpButtonTiles, RunDownButtonTiles;
        [SerializeField] GameObject[] FallButtonTiles;

        bool isButtonDown = false, isButtonUp = true;

        IEnumerator RunUpCoroutine = null, RunDownCoroutine = null;

        PlayerInputButtonStateControl PlayerButtonState;

        private void Start()
        {
            PlayerButtonState = FindObjectOfType<PlayerInputButtonStateControl>();
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
            switch (ButtonName)
            {
                case "JumpButton":
                    isButtonUp = false;
                    float WaitTime = 0.35f;
                    int YellowBoxCount = 0;
                    PlayerArrowControl.ChargeCount = 0;
                    for (float i = 0; i < JumpButtonTiles.Length; i++)
                        {
                        if (i % 2 == 1)
                            JumpYellowBoxParts[YellowBoxCount++].SetActive(true);
                        JumpButtonTiles[(int)i].SetActive(true);
                        PlayerArrowControl.ChargeCount++;
                        WaitTime -= 0.025f;
                        yield return new WaitForSeconds(WaitTime);
                         }
                    for (int i = 0; i < 3; i++)
                        {
                        for (int j = 0; j < JumpButtonTiles.Length; j++)
                            JumpButtonTiles[j].SetActive(false);
                        for (int j = 0; j < JumpYellowBoxParts.Length; j++)
                            JumpYellowBoxParts[j].SetActive(false);
                        yield return new WaitForSeconds(0.1f);
                        for (int j = 0; j < JumpButtonTiles.Length; j++)
                            JumpButtonTiles[j].SetActive(true);
                        for (int j = 0; j < JumpYellowBoxParts.Length; j++)
                            JumpYellowBoxParts[j].SetActive(true);
                        yield return new WaitForSeconds(0.1f);
                         }
                    for (int j = 0; j < JumpButtonTiles.Length; j++)
                        JumpButtonTiles[j].SetActive(false);
                    for (int j = 0; j < JumpYellowBoxParts.Length; j++)
                        JumpYellowBoxParts[j].SetActive(false);
                    isButtonUp = true;
                    break;

                case "RunUpButton":
                    if (PlayerButtonState.GetButtonState() != InputButtonType.RUN)
                        break;
                    for (int i = 3; i < RunUpButtonTiles.Length; i++)
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
                    if (PlayerButtonState.GetButtonState() != InputButtonType.RUN)
                        break;
                    for (int i = RunDownButtonTiles.Length - 4; i > -1; i--)
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
                    isButtonUp = false;
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
                    isButtonUp = true;
                    break;
            }
        }

        private void Update()
        {
            if (isButtonDown && isButtonUp && PlayerButtonState.GetButtonState() == InputButtonType.FALL)
                StartCoroutine(ButtonClick("FallButton"));

            if (isButtonDown && isButtonUp && PlayerButtonState.GetButtonState() == InputButtonType.JUMP)
                StartCoroutine(ButtonClick("JumpButton"));
        }

        public void FallButtonDown()
        {
            isButtonDown = true;
        }

        public void FallButtonUp()
        {
            isButtonDown = false;
        }

        public void JumpButtonDown()
        {
            isButtonDown = true;
        }

        public void JumpButtonUp()
        {
            isButtonDown = false;
            StopAllCoroutines();
            isButtonUp = true;
            FindObjectOfType<PlayerControl>().PlayerJump();
            FindObjectOfType<PlayerControl>().isGround = false;
            for (int i = 0; i < JumpButtonTiles.Length; i++)
                JumpButtonTiles[i].SetActive(false);
            for (int i = 0; i < JumpYellowBoxParts.Length; i++)
                JumpYellowBoxParts[i].SetActive(false);
            PlayerArrowControl.ChargeCount = 0;
        }

    }
}