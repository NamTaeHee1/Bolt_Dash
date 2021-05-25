using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoPanelControl : MonoBehaviour
{
    [SerializeField] private Animator InfoPanelAnim;
    [SerializeField] private TextMeshProUGUI TitleText;

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
}
