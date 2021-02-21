using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool GameStarted = false;
    [SerializeField]
    GameObject LeftThorn, RightThorn, StartPosition;
    Transform LeftThornTransform, RightThornTransform, StartPositionTransform;
    RectTransform BestScoreRectTransform;
    Vector3 BestScoreTargetPosition;
    [SerializeField]
    private float ObjectSpeed = 0.5f;
    public GameObject[] gameObjects;
    // Start is called before the first frame update
    void Start()
    {
        LeftThornTransform = LeftThorn.GetComponent<Transform>();
        RightThornTransform = RightThorn.GetComponent<Transform>();
        StartPositionTransform = StartPosition.GetComponent<Transform>();
        BestScoreRectTransform = gameObjects[2].GetComponent<RectTransform>();
        BestScoreTargetPosition = new Vector3(BestScoreRectTransform.localPosition.x, -956, BestScoreRectTransform.localPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStarted)
        {
            GameStart();
            SettingBestScore();
        }
        else
        {
            LeftThorn.SetActive(false);
            RightThorn.SetActive(false);
            StartPosition.SetActive(false);
        }
    }


    public void GameStart()
    {
        LeftThorn.SetActive(true);
        RightThorn.SetActive(true);
        StartPosition.SetActive(true);
        LeftThornTransform.position = Vector3.Lerp(LeftThornTransform.position, new Vector3(0, LeftThornTransform.position.y, LeftThornTransform.position.z), ObjectSpeed);
        RightThornTransform.position = Vector3.Lerp(RightThornTransform.position, new Vector3(0, RightThornTransform.position.y, RightThornTransform.position.z), ObjectSpeed);
        StartPositionTransform.position = Vector3.Lerp(StartPositionTransform.position, new Vector3(StartPositionTransform.position.x, -4.7f, StartPositionTransform.position.z), ObjectSpeed);

        for(int i = 0; i < gameObjects.Length; i++)
        {
            gameObjects[0].GetComponent<Rigidbody2D>().AddForce(Vector2.right * ObjectSpeed, ForceMode2D.Impulse);
            gameObjects[1].GetComponent<Rigidbody2D>().AddForce(Vector2.left * ObjectSpeed, ForceMode2D.Impulse);
            gameObjects[3].GetComponent<Rigidbody2D>().AddForce(Vector2.down * ObjectSpeed, ForceMode2D.Impulse);
            gameObjects[4].GetComponent<Rigidbody2D>().AddForce(Vector2.down * ObjectSpeed, ForceMode2D.Impulse);
            gameObjects[5].GetComponent<Rigidbody2D>().AddForce(Vector2.down * ObjectSpeed, ForceMode2D.Impulse);
            gameObjects[6].GetComponent<Rigidbody2D>().AddForce(Vector2.down * ObjectSpeed, ForceMode2D.Impulse);
            gameObjects[7].GetComponent<Rigidbody2D>().AddForce(Vector2.right * ObjectSpeed, ForceMode2D.Impulse);
            gameObjects[8].GetComponent<Rigidbody2D>().AddForce(Vector2.right * ObjectSpeed, ForceMode2D.Impulse);
            gameObjects[9].GetComponent<Rigidbody2D>().AddForce(Vector2.left * ObjectSpeed, ForceMode2D.Impulse);
            gameObjects[10].GetComponent<Rigidbody2D>().AddForce(Vector2.left * ObjectSpeed, ForceMode2D.Impulse);
        }
    }

    void SettingBestScore()
    {
        BestScoreRectTransform.localPosition = Vector3.Lerp(BestScoreRectTransform.position, BestScoreTargetPosition, ObjectSpeed);
    }
}
