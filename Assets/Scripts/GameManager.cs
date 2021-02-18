using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool GameStarted = false;
    [SerializeField]
    GameObject LeftThorn, RightThorn, StartPosition;
    Transform LeftThornTransform, RightThornTransform, StartPositionTransform;
    [SerializeField]
    private float ObjectSpeed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        LeftThornTransform = LeftThorn.GetComponent<Transform>();
        RightThornTransform = RightThorn.GetComponent<Transform>();
        StartPositionTransform = StartPosition.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStarted)
        {
            GameStart();
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
    }
}
