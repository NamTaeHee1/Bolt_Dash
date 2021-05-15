using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PauseButtonControl : MonoBehaviour
{
    [SerializeField] private Animator PauseButtonAnim;
    [SerializeField] private GameObject PauseButtonMovement, PauseImage, PlayImage;
    bool isON = false;

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
        Debug.Log(PauseButtonAnim.GetCurrentAnimatorStateInfo(0).IsName("PauseButtonClickOFF"));
/*        if (PauseButtonAnim.GetCurrentAnimatorStateInfo(0).IsName(isON ? "PauseButtonClickOFF" : "PauseButtonClickON")
            && PauseButtonAnim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.99f)
            PauseButtonAnim.SetBool("isON", isON);*/

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
