using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AcadeSceneInfo : ScriptableObject
{
    public string AcadeLevel; //스테이지 레벨

    public float MainSceneCameraX; //현재 스테이지 레벨에 맞는 Camera x좌표

    public bool isAchieve; //스테이지를 달성했는가
}
