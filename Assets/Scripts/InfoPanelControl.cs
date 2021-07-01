using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class InfoPanelControl : MonoBehaviour
{
    [SerializeField] private Animator InfoPanelAnim;

    [SerializeField] private TextMeshProUGUI TitleText;

    [SerializeField] private GameObject PauseButtonPanelBlock;

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
        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            if (TitleText.text.Contains("Á¾·á"))
            {
                FindObjectOfType<MainSceneManager>().CreateMainSceneReloadObject();
                LoadingManager.LoadScene("MainScene");
            }
            else
                FindObjectOfType<GameManager>().ReStart();
        }
        else if(SceneManager.GetActiveScene().name == "AcadeScene")
        {
            LoadingManager.LoadScene("GameScene");
        }
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
        PauseButtonPanelBlock.SetActive(false);
    }
}
