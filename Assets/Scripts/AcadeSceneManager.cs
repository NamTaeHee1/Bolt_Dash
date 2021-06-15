using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AcadeSceneManager : MonoBehaviour
{
    static public string AcadeLevel;
    void Start()
    {
        StartCoroutine(StartAnimation());
    }

    IEnumerator StartAnimation()
    {
        LoadingManager.FadeIn();
        yield return new WaitForSeconds(1.0f);

    }
}
