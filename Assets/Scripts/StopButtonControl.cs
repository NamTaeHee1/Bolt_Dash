using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StopButtonControl : MonoBehaviour
{
    [SerializeField] Animator StopButtonAnim;
    [SerializeField] private GameObject StopButton, StopImage, PlayImage;
    bool isON = false;

    public void StopButtonClick()
    {
        Debug.Log("Å¬¸¯");
        isON = !isON;
        StopButtonAnim.SetBool("isON", isON);
        StopImage.SetActive(isON ? false : true);
        PlayImage.SetActive(isON ? true : false);

    }

    public void GameStart()
    {
        Debug.Log("fweufwe");
        //StopButton.GetComponent<RectTransform>().DOAnchorPosY(0, 1.0f).SetEase(Ease.OutElastic);
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
