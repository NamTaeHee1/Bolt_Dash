using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DanielLochner.Assets.SimpleScrollSnap;

public class AcadeSceneManager : MonoBehaviour
{
    static public string AcadeLevel;

    [SerializeField] TextMeshProUGUI ShowLevelText;

    [SerializeField] SimpleScrollSnap PlayerInputScrollSnap;

    void Start()
    {
        StartCoroutine(StartAnimation());
        SettingInputPanel();
    }

    IEnumerator StartAnimation()
    {
        LoadingManager.FadeIn();
        yield return new WaitForSeconds(1.0f);
        for(int i = 0; i < AcadeLevel.Length; i++)
        {
            ShowLevelText.text += AcadeLevel[i];
            yield return new WaitForSeconds(0.3f);
        }
    }

    void SettingInputPanel()
    {
        int AcadeLevelNumber = int.Parse(AcadeLevel[5].ToString());
        if (AcadeLevelNumber >= 7)
            PlayerInputScrollSnap.startingPanel = 1;
        else if (AcadeLevelNumber >= 4)
            PlayerInputScrollSnap.startingPanel = 2;
        else
            PlayerInputScrollSnap.startingPanel = 3;
    }
}
