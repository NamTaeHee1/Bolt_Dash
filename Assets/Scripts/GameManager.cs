using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    static public TextMeshProUGUI BestScoreText;
    [SerializeField] GameObject[] GameObjects;
    IEnumerator ScoreSettingCoroutine = null;

    void Start()
    {
        BestScoreText = GameObjects[0].GetComponent<TextMeshProUGUI>();
    }
   
    public void GameStart()
    {
        BeforeTheGameStartProduction();
        SettingScoreText();
        StartCoroutine(HideMenuObject());
    }

    public void ReStart()
    {
        GameObjects[0].GetComponent<Animator>().Play("GameStart", -1, 0f);
        SettingScoreText();
        FindObjectOfType<PauseButtonControl>().StopButtonClick("ReStart");
    }

    public void BeforeTheGameStartProduction()
    {
        for (int i = 0; i < GameObjects.Length; i++)
            GameObjects[i].GetComponent<Animator>().SetTrigger("GameStart");
        FindObjectOfType<PauseButtonControl>().GameStart();
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
        for (int i = 1; i < GameObjects.Length; i++)
            GameObjects[i].SetActive(false);
    }
}
