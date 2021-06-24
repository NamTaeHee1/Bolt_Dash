using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI BestScoreText;

    [SerializeField] GameObject[] MainGameObjects;
    [SerializeField] GameObject HideObject;
    [SerializeField] GameObject InGameCanvas;
    [SerializeField] GameObject ToMoveObjects;

    IEnumerator ScoreSettingCoroutine = null;
   
    public void GameStart()
    {
        BeforeTheGameStartProduction();
        SettingScoreText();
        StartCoroutine(HideMenuObject());
    }

    public void ReStart()
    {
        MainGameObjects[0].GetComponent<Animator>().Play("GameStart", -1, 0f);
        SettingScoreText();
        FindObjectOfType<PauseButtonControl>().StopButtonClick("ReStart");
    }

    public void BeforeTheGameStartProduction()
    {
        for (int i = 0; i < MainGameObjects.Length; i++)
            MainGameObjects[i].GetComponent<Animator>().SetTrigger("GameStart");
        FindObjectOfType<PauseButtonControl>().GameStart();
        MoveToInGameCanvas();
    }

    void SettingScoreText()
    {
        if(ScoreSettingCoroutine != null)
        {
            StopCoroutine(ScoreSettingCoroutine);
            BestScoreText.text = "";
        }
        ScoreSettingCoroutine = BestScoreToScore();
        StartCoroutine(ScoreSettingCoroutine);
    }

    void MoveToInGameCanvas()
    {
        ToMoveObjects.transform.parent = InGameCanvas.transform;
    }

    IEnumerator BestScoreToScore()
    {
        string Score = "Score\n0";
        
        BestScoreText.text = "";
        yield return new WaitForSeconds(1.0f);
        for (int i = 0; i < Score.Length; i++)
        {
            BestScoreText.text += Score[i];
            yield return new WaitForSeconds(0.4f);
        }
    }

    IEnumerator HideMenuObject()
    {
        yield return new WaitForSecondsRealtime(3.0f);
        HideObject.SetActive(false);
    }
}
