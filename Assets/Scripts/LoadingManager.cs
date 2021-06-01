using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadingManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] LoadingText;
    [SerializeField] Image ProgressBar;

    private void Start()
    {
        StartCoroutine(LoadingTextAnimation());
    }

    IEnumerator LoadingTextAnimation()
    {
        while (true)
        {
            for (int i = 0; i < LoadingText.Length; i++)
            {
                LoadingText[i].color = new Color32(255, 255, 255, 255);
                yield return new WaitForSeconds(0.3f);
            }
            for (int i = 0; i < LoadingText.Length; i++)
                LoadingText[i].color = new Color32(255, 255, 255, 130);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
