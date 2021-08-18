using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DanielLochner.Assets.SimpleScrollSnap;

public class AcadeSceneManager : MonoBehaviour
{
    static public string AcadeLevel;

    static public float MainSceneCameraX;

    static public bool isAchieve;

    private PlayerInputButtonStateControl PlayerButtonControl;

    [SerializeField] private TextMeshProUGUI ShowLevelText;

    [SerializeField] private SimpleScrollSnap PlayerInputScrollSnap;

    [SerializeField] private GameObject AcadeInfoObject;

    [SerializeField] private Image[] PlayerInputPanelImages;

    [SerializeField] private PauseButtonControl PauseButton;

    private void Awake()
    {
        FadeManager.instance.FadeIn();
        PlayerButtonControl = FindObjectOfType<PlayerInputButtonStateControl>();
    }

    private void Start()
    {
        StartCoroutine(StartAnimation());
        SettingInputPanel();
    }

    private void SettingInputPanel()
    {
        int Level = int.Parse(AcadeLevel);
        if (Level >= 7)
            PlayerButtonControl.SetButtonState(2);
        else if (Level >= 4)
            PlayerButtonControl.SetButtonState(1);
        else
            PlayerButtonControl.SetButtonState(0);
    }

    IEnumerator StartAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        PauseButton.GameStart(1052f, 840f);
        for(int i = 0; i < AcadeLevel.Length; i++)
        {
            ShowLevelText.text += AcadeLevel[i];
            yield return new WaitForSeconds(0.3f);
        }
    }

    public void CreateAcadeSceneInfoObject()
    {
        GameObject AcadeSceneInfoObject = Instantiate(AcadeInfoObject);
        DontDestroyOnLoad(AcadeSceneInfoObject);
    }
}
