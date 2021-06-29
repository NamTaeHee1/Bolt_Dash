using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadingManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] LoadingText;

    [SerializeField] Image ProgressBar;

    [SerializeField] GameObject MainSceneReload;

    public static string NextScene = "";

    public bool isSuccessLoadScene = false;

    private void Start()
    {
        StartCoroutine(LoadingTextAnimation());
        StartCoroutine(LoadScene());
    }

    public static void LoadScene(string SceneName)
    {
        Time.timeScale = 1f;
        FadeOut();
        NextScene = SceneName;
        SceneManager.LoadScene("LoadingScene");
    }

    IEnumerator LoadScene()
    {
        FadeIn();
        yield return new WaitForSecondsRealtime(1.0f);
        AsyncOperation Op = SceneManager.LoadSceneAsync(NextScene);
        Op.allowSceneActivation = false;
        float Timer = 0.0f;
        while(!Op.isDone)
        {
            yield return null;
            Timer += Time.deltaTime;
            if(Op.progress < 0.9f)
            {
                ProgressBar.fillAmount = Mathf.Lerp(ProgressBar.fillAmount, Op.progress, Timer);
                if (ProgressBar.fillAmount >= Op.progress)
                    Timer = 0;
            }
            else
            {
                ProgressBar.fillAmount = Mathf.Lerp(ProgressBar.fillAmount, 1f, Timer);
                if(ProgressBar.fillAmount == 1.0f)
                {
                    isSuccessLoadScene = true;
                    FadeOut();
                    yield return new WaitForSecondsRealtime(0.5f);
                    Op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }

    IEnumerator LoadingTextAnimation()
    {
        while (true)
        {
            if (!isSuccessLoadScene)
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

    public static void FadeIn() //¹à°Ô
    {
        GameObject.Find("BlackScreen").GetComponent<Animator>().Play("FadeIn", -1, 0f);
        Debug.Log("¹à°Ô");
    }

    public static void FadeOut() //¾îµÓ°Ô
    {
        GameObject.Find("BlackScreen").GetComponent<Animator>().Play("FadeOut", -1, 0f);
        Debug.Log("¾îµÓ°Ô");
    }
}
