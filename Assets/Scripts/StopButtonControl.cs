using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopButtonControl : MonoBehaviour
{
    Animator StopButtonAnim;
    [SerializeField] private GameObject StopButton;
    [SerializeField] private GameObject StopImage, PlayImage;
    bool isON = false;
    
    private void Awake() => StopButtonAnim = StopButton.GetComponent<Animator>();

    public void StopButtonClick()
    {
        Debug.Log("Å¬¸¯");
        isON = !isON;
        StopButtonAnim.SetBool("isON", isON);
        StopImage.SetActive(isON ? false : true);
        PlayImage.SetActive(isON ? true : false);

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
