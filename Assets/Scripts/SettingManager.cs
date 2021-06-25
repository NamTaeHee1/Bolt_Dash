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

    [SerializeField] Animator SettingAnim;

    [SerializeField] Slider LightControlSlider, SoundEffectControlSlider, BGMSoundControlSlider;

    [SerializeField] TextMeshProUGUI LightControlSliderValueText, SoundEffectControlSliderValueText, BGMSoundControlSliderValueText;

    [SerializeField] private PostProcessVolume PostProcessVolume;

    Bloom Bloom;

    FloatParameter floatParameter;

    void Start()
    {
        Bloom = PostProcessVolume.profile.GetSetting<Bloom>();
        floatParameter = new FloatParameter();
    }

    public void ClickSetting()
    {
        SettingParents.SetActive(true);
        SettingAnim.Play("SettingON", -1, 0f);
        for (int i = 0; i < Buttons.Length; i++)
        {
            Buttons[i].interactable = false;
        }
    }

    public void SettingClickBackButton()
    {
        SettingAnim.Play("SettingOFF", -1, 0f);
        StartCoroutine(ExitSetting());
    }

    IEnumerator ExitSetting()
    {
        yield return new WaitForSecondsRealtime(0.55f);
        SettingParents.SetActive(false);
        for (int i = 0; i < Buttons.Length; i++)
            Buttons[i].interactable = true;
        PauseButtonBlock.SetActive(false);
    }

    public void LightControlSliderChangeValue()
    {
        floatParameter.value = LightControlSlider.value;
        Bloom.intensity.Override(floatParameter);
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
