using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PauseButtonControl : MonoBehaviour
{
    [SerializeField] private Animator PauseButtonAnim;
    [SerializeField] private GameObject PauseButtonMovement, PauseImage, PlayImage;
    [SerializeField] private Image[] ButtonImages;
    bool isON = false;
    private float AlphaThreshold = 0.1f;

    private void Start()
    {
        for (int i = 0; i < ButtonImages.Length; i++)
            ButtonImages[i].alphaHitTestMinimumThreshold = AlphaThreshold;
    }

    public void GameStart()
    {
        PauseButtonMovement.GetComponent<RectTransform>().DOAnchorPosY(-955.3f, 1.0f).SetEase(Ease.OutBack);
    }

    public void StopButtonClick()
    {
        Debug.Log("Å¬¸¯");
        isON = !isON;
        PauseImage.SetActive(isON ? false : true);
        PlayImage.SetActive(isON ? true : false);
        PauseButtonAnim.SetBool("isON", isON);
    }

    public void RunButtonClick()
    {
        Debug.Log("Run");
    }

    public void SettingButtonClick()
    {
        Debug.Log("Setting");
    }

    public void QuitButtonClick()
    {
        Debug.Log("Quit");
    }
}
