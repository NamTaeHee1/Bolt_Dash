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

    [SerializeField] TextMeshProUGUI ShowLevelText;

    [SerializeField] SimpleScrollSnap PlayerInputScrollSnap;

    [SerializeField] GameObject AcadeInfoObject;

    [SerializeField] PauseButtonControl PauseButton;

    void Start()
    {
        StartCoroutine(StartAnimation());
        SettingInputPanel();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            LoadingManager.LoadScene("GameScene");
    }
    IEnumerator StartAnimation()
    {
        LoadingManager.FadeIn();
        yield return new WaitForSeconds(1.0f);
        PauseButton.GameStart(1052f, 840f);
        for(int i = 0; i < AcadeLevel.Length; i++)
        {
            ShowLevelText.text += AcadeLevel[i];
            yield return new WaitForSeconds(0.3f);
        }
    }

    void SettingInputPanel()
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
