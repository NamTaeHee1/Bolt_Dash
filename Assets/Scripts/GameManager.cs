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
    [SerializeField]
    private float ObjectSpeed = 0.5f;
    public GameObject[] gameObjects;
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
            BeforeTheGameStarts();
        }
        else
        {
            LeftThorn.SetActive(false);
            RightThorn.SetActive(false);
            StartPosition.SetActive(false);
        }
    }


    public void BeforeTheGameStarts()
    {
        
    }


    IEnumerator WaitAnimation()
    {
        yield return new WaitForSeconds(1.0f);
        Debug.Log("1");
        yield return new WaitForSeconds(1.0f);
        Debug.Log("2");
    }

}
