using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoPanelControl : MonoBehaviour
{
    [SerializeField] private Animator InfoPanelAnim;
    [SerializeField] private TextMeshProUGUI TitleText;
    [SerializeField] private GameObject PauseButtonBlock;

    private void OnEnable()
    {
        InfoPanelAnim.SetBool("isON", true);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SendText(string TitleText)
    {
        this.TitleText.text = TitleText;
    }

    public void ClickYes()
    {
        if (TitleText.text.Contains("종료"))
        {
            Debug.Log("종료!");
        }
        else
            FindObjectOfType<GameManager>().ReStart();
    }

    public void ClickNo()
    {
        InfoPanelAnim.SetBool("isON", false);
        StartCoroutine(ExitInfo());
    }

    IEnumerator ExitInfo()
    {
        yield return new WaitForSecondsRealtime(0.55f);
        this.gameObject.SetActive(false);
        PauseButtonBlock.SetActive(false);
    }
}
