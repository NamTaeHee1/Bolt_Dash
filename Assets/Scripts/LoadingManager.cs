using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadingManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] LoadingText;

    private void Start()
    {
        StartCoroutine(LoadingTextAnimation());
    }

    IEnumerator LoadingTextAnimation()
    {
        yield return null;
    }
}
