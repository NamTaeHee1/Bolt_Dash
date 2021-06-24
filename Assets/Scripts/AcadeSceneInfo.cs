using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcadeSceneInfo : MonoBehaviour
{
    public string AcadeLevel;

    public float MainSceneCameraX;

    private bool isAchieve;

    public AcadeSceneInfo()
    {
        AcadeLevel = AcadeSceneManager.AcadeLevel;
        MainSceneCameraX = AcadeSceneManager.MainSceneCameraX;
        isAchieve = AcadeSceneManager.isAchieve;
    }
}
