using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopButtonControl : MonoBehaviour
{
    Animator StopButtonAnim;
    [SerializeField] private GameObject StopButton;
    [SerializeField] private Button[] buttons;

    private void Awake()
    {
        StopButtonAnim = StopButton.GetComponent<Animator>();
    }

    public void StopButtonClick()
    {
        Debug.Log("Click");
        StopButtonAnim.SetTrigger("isClick");
        buttons[0].gameObject.SetActive(false);
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
