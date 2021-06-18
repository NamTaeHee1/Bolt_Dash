using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class InfoPanelControl : MonoBehaviour
{
    [SerializeField] private Animator InfoPanelAnim;
    [SerializeField] private TextMeshProUGUI TitleText;
    [SerializeField] private GameObject PauseButtonBlock, PauseButtonPanelBlock;

    private void OnEnable()
    {
        InfoPanelAnim.SetBool("isON", true);
    }

    public void SendText(string TitleText)
    {
        PauseButtonPanelBlock.SetActive(true);
        this.TitleText.text = TitleText;
    }

    public void ClickYes()
    {
        if (TitleText.text.Contains("Á¾·á"))
            SceneManager.LoadScene("GameScene");
        else
            FindObjectOfType<GameManager>().ReStart();
        Time.timeScale = 1;
        ClickNo();
    }

    public void ClickNo()
    {
        InfoPanelAnim.SetBool("isON", false);
        StartCoroutine(ExitInfo());
    }

    IEnumerator ExitInfo()
    {
        yield return new WaitForSecondsRealtime(0.4f);
        this.gameObject.SetActive(false);
        PauseButtonBlock.SetActive(false);
    }
}
