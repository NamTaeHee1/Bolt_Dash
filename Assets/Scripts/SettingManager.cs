using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class SettingManager : MonoBehaviour
{
    public Button[] Buttons;
    public GameObject SettingParents;
    public GameObject SettingObject;
    [SerializeField]
    GameObject SettingPanelImage;
    Animator SettingPanelImageAnim;
    [SerializeField]
    GameObject SettingPanelLeftLine;
    Animator SettingPanelLeftLineAnim;
    [SerializeField]
    GameObject SettingPanelRightLine;
    Animator SettingPanelRightLineAnim;
    [SerializeField]
    Slider LightControlSlider, SoundControlSlider;
    [SerializeField]
    private PostProcessVolume activeVolume;
    // Start is called before the first frame update
    void Start()
    {
        SettingPanelImageAnim = SettingPanelImage.GetComponent<Animator>();
        SettingPanelLeftLineAnim = SettingPanelLeftLine.GetComponent<Animator>();
        SettingPanelRightLineAnim = SettingPanelRightLine.GetComponent<Animator>();
    }

    public void ClickSetting()
    {
        SettingParents.SetActive(true);
        SettingPanelImageAnim.SetBool("isON", true);
        SettingPanelLeftLineAnim.SetBool("isON", true);
        SettingPanelRightLineAnim.SetBool("isON", true);
        for (int i = 0; i < Buttons.Length; i++)
        {
            Buttons[i].interactable = false;
        }
        Invoke("ShowSettingItem", 0.63f);
    }

    public void SettingClickBackButton()
    {
        SettingObject.SetActive(false);
        SettingPanelImageAnim.SetBool("isON", false);
        SettingPanelLeftLineAnim.SetBool("isON", false);
        SettingPanelRightLineAnim.SetBool("isON", false);
        Invoke("ExitSetting", 0.65f);
    }

    void ExitSetting()
    {
        SettingParents.SetActive(false);
        for (int i = 0; i < Buttons.Length; i++)
            Buttons[i].interactable = true;
    }

    void ShowSettingItem()
    {
        SettingObject.SetActive(true);
    }

    void LightControlSliderChangeValue()
    {
        Bloom bloom;
        activeVolume.profile.TryGetSettings(out bloom);
        
    }
}
