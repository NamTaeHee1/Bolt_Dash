using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadingManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI LoadingText;

    private void Start()
    {
        StartCoroutine(LoadingTextAnimation());
    }

    IEnumerator LoadingTextAnimation()
    {
        char[] Loading = new char[] { 'L', 'O', 'A', 'D', 'I', 'N', 'G', '.', '.', '.' };
        for(int i = 0; i < Loading.Length; i++)
        {
            LoadingText.text += Loading[i];
            yield return new WaitForSeconds(0.3f);
        }
    }
}
