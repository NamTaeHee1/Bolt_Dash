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
    Slider LightControlSlider, SoundEffectControlSlider, BGMSoundControlSlider;
    [SerializeField]
    Text LightControlSliderValueText, SoundEffectControlSliderValueText, BGMSoundControlSliderValueText;
    [SerializeField]
    private PostProcessVolume postProcessVolume;
    Bloom bloom;
    FloatParameter floatParameter;
    // Start is called before the first frame update
    void Start()
    {
        SettingPanelImageAnim = SettingPanelImage.GetComponent<Animator>();
        SettingPanelLeftLineAnim = SettingPanelLeftLine.GetComponent<Animator>();
        SettingPanelRightLineAnim = SettingPanelRightLine.GetComponent<Animator>();
        bloom = postProcessVolume.profile.GetSetting<UnityEngine.Rendering.PostProcessing.Bloom>();
        floatParameter = new UnityEngine.Rendering.PostProcessing.FloatParameter();
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

    public void LightControlSliderChangeValue()
    {
        floatParameter.value = LightControlSlider.value;
        bloom.intensity.Override(floatParameter);
        ShowValue(LightControlSlider, LightControlSliderValueText);
    }

    public void SoundEffectSliderChangeValue()
    {

    }

    public void BGMSoundSliderChangeValue()
    {

    }

    IEnumerator ShowValue(Slider slider, Text sliderValueText)
    {
        sliderValueText.text = slider.value.ToString();
        yield return new WaitForSeconds(1.0f);
    }
}
