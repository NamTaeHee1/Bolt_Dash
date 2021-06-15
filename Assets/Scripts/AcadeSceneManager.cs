using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcadeSceneManager : MonoBehaviour
{
    static public string AcadeLevel;
    void Start()
    {
        LoadingManager.FadeIn();
    }

    void Update()
    {
        Debug.Log(AcadeLevel);
    }
}
