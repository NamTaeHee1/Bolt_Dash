using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcadeSceneInfo : MonoBehaviour
{
    private string AcadeLevel;

    private float MainSceneCameraX;

    private bool isAchieve;

    public AcadeSceneInfo()
    {
        AcadeLevel = AcadeSceneManager.AcadeLevel;
        MainSceneCameraX = AcadeSceneManager.MainSceneCameraX;
        isAchieve = AcadeSceneManager.isAchieve;
    }
}
