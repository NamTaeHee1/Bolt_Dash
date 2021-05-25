using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class PauseButtonControl : MonoBehaviour
{
    [SerializeField] private Animator PauseButtonAnim, PauseButtonPanelAnim;
    [SerializeField] private GameObject PauseButtonMovement, PauseImage, PlayImage, PauseButtonPanelBlock;
    [SerializeField] private Image[] ButtonImages;
    [SerializeField] private Image PauseButtonPanel;
    [SerializeField] private Button PauseButton;
    [SerializeField] private TextMeshProUGUI PauseCountDownText;
    bool isON = false, isPause = false;
    private float AlphaThreshold = 0.1f;

    private void Start()
    {
        for (int i = 0; i < ButtonImages.Length; i++)
            ButtonImages[i].alphaHitTestMinimumThreshold = AlphaThreshold;
    }

    public void GameStart()
    {
        PauseButtonMovement.GetComponent<RectTransform>().DOAnchorPosY(-955.3f, 1.0f).SetEase(Ease.OutBack);
        StartCoroutine(InteractableOnPauseButton());
    }

    IEnumerator InteractableOnPauseButton()
    {
        yield return new WaitForSeconds(1.0f);
        PauseButton.interactable = true;
    }

    public void StopButtonClick()
    {
        Debug.Log("Å¬¸¯");
        isON = !isON;
        isPause = !isPause;
        PauseImage.SetActive(isON ? false : true);
        PlayImage.SetActive(isON ? true : false);
        PauseButtonAnim.SetBool("isON", isON);
        if (isPause)
            Time.timeScale = 0;
        else
            StartCoroutine(PauseCountDown());
        PauseButtonPanel.color = new Color(0, 0, 0, 0.3f);
    }

    IEnumerator PauseCountDown()
    {
        PauseButtonPanelBlock.SetActive(true);
        for(int i = 0; i < 3; i++)
        {
            PauseCountDownText.text = (3 - i).ToString();
            PauseButtonPanelAnim.Play("PauseOffCountDown", -1, 0f);
            yield return new WaitForSecondsRealtime(1.0f);
        }
        Time.timeScale = 1;
        PauseCountDownText.text = "";
        PauseButtonPanelBlock.SetActive(false);
        PauseButtonPanel.color = new Color(0, 0, 0, 0);
    }

    public void ReStartButtonClick()
    {
        Debug.Log("Restart");
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
