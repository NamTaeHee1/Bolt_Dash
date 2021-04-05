using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool GameStarted = false;
    [SerializeField]
    GameObject LeftThorn, RightThorn, StartPosition;
    Transform LeftThornTransform, RightThornTransform, StartPositionTransform;
    static public TextMeshProUGUI BestScoreText;
    [SerializeField]
    GameObject[] GameObjects;
    bool GameStart = false;
    // Start is called before the first frame update
    void Start()
    {
        LeftThornTransform = LeftThorn.GetComponent<Transform>();
        RightThornTransform = RightThorn.GetComponent<Transform>();
        StartPositionTransform = StartPosition.GetComponent<Transform>();
        BestScoreText = GameObjects[0].GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStarted)
        {
            if (!GameStart)
            {
                GameStart = true;
                BeforeTheGameStartProduction();
                StartCoroutine(BestScoreToScore());
                StartCoroutine(HideMenuObject());
            }
        }
        else
        {
            LeftThorn.SetActive(false);
            RightThorn.SetActive(false);
        }
    }
   

    public void BeforeTheGameStartProduction()
    {
        for (int i = 0; i < GameObjects.Length; i++)
            GameObjects[i].GetComponent<Animator>().SetTrigger("GameStart");
    }


    IEnumerator BestScoreToScore()
    {
        string[] score = new string[] { "S", "C", "O", "R", "E", "\n", "0" };
        
        BestScoreText.text = "";
        yield return new WaitForSeconds(1.0f);
        for (int i = 0; i < score.Length; i++)
        {
            BestScoreText.text += score[i];
            yield return new WaitForSeconds(0.3f);
        }
    }


    IEnumerator HideMenuObject()
    {
        yield return new WaitForSeconds(3.0f);
        for (int i = 1; i < GameObjects.Length - 1; i++)
            GameObjects[i].SetActive(false);
    }
}
