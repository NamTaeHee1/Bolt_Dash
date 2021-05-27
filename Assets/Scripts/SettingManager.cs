using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using TMPro;

public class SettingManager : MonoBehaviour
{
    public Button[] Buttons;
    public GameObject SettingParents;
    public GameObject SettingObject;
    [SerializeField] GameObject SettingPanelImage, SettingPanelLeftLine, SettingPanelRightLine, PauseButtonBlock;
    Animator SettingPanelImageAnim, SettingPanelLeftLineAnim, SettingPanelRightLineAnim;
    [SerializeField] Slider LightControlSlider, SoundEffectControlSlider, BGMSoundControlSlider;
    [SerializeField] TextMeshProUGUI LightControlSliderValueText, SoundEffectControlSliderValueText, BGMSoundControlSliderValueText;
    [SerializeField] private PostProcessVolume PostProcessVolume;
    Bloom bloom;
    FloatParameter floatParameter;

    void Start()
    {
        SettingPanelImageAnim = SettingPanelImage.GetComponent<Animator>();
        SettingPanelLeftLineAnim = SettingPanelLeftLine.GetComponent<Animator>();
        SettingPanelRightLineAnim = SettingPanelRightLine.GetComponent<Animator>();
        bloom = PostProcessVolume.profile.GetSetting<Bloom>();
        floatParameter = new FloatParameter();
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
    }

    public void SettingClickBackButton()
    {
        SettingPanelImageAnim.SetBool("isON", false);
        SettingPanelLeftLineAnim.SetBool("isON", false);
        SettingPanelRightLineAnim.SetBool("isON", false);
        StartCoroutine(ExitSetting());
    }

    IEnumerator ExitSetting()
    {
        yield return new WaitForSecondsRealtime(0.65f);
        SettingParents.SetActive(false);
        for (int i = 0; i < Buttons.Length; i++)
            Buttons[i].interactable = true;
        PauseButtonBlock.SetActive(false);
    }

    public void LightControlSliderChangeValue()
    {
        floatParameter.value = LightControlSlider.value;
        bloom.intensity.Override(floatParameter);
        ShowValue(LightControlSlider, LightControlSliderValueText);
    }

    public void SoundEffectSliderChangeValue()
    {
        ShowValue(SoundEffectControlSlider, SoundEffectControlSliderValueText);
    }

    public void BGMSoundSliderChangeValue()
    {
        ShowValue(BGMSoundControlSlider, BGMSoundControlSliderValueText);
    }

    void ShowValue(Slider Slider, TextMeshProUGUI SliderValueText)
    {
        SliderValueText.text = ((int)Slider.value).ToString();
    }
}
