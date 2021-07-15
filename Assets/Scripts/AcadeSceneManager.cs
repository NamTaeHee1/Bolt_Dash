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

    [SerializeField] private TextMeshProUGUI ShowLevelText;

    [SerializeField] private SimpleScrollSnap PlayerInputScrollSnap;

    [SerializeField] private GameObject AcadeInfoObject;

    [SerializeField] private PauseButtonControl PauseButton;

    private void Awake()
    {
        FadeManager.instance.FadeIn();
    }

    private void Start()
    {
        StartCoroutine(StartAnimation());
        SettingInputPanel();
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

    private void SettingInputPanel()
    {
        int AcadeLevelNumber = int.Parse(AcadeLevel[6].ToString());
        if (AcadeLevelNumber >= 7) // FALL
            PlayerInputScrollSnap.startingPanel = 2;
        else if (AcadeLevelNumber >= 4) // RUN
            PlayerInputScrollSnap.startingPanel = 1;
        else // JUMP
            PlayerInputScrollSnap.startingPanel = 0;
    }

    public void CreateAcadeSceneInfoObject()
    {
        GameObject AcadeSceneInfoObject = Instantiate(AcadeInfoObject);
        DontDestroyOnLoad(AcadeSceneInfoObject);
    }
}
