using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneManager : MonoBehaviour
{
    private GameObject AcadeSceneInfo;
    public static bool isClickPauseButtonQuit;

    private void Awake()
    {
        AcadeSceneInfo = GameObject.Find("AcadeSceneInfo") != null ? GameObject.Find("AcadeSceneInfo").gameObject : null;
    }

    private void Start()
    {
        if (isClickPauseButtonQuit)
            LoadingManager.FadeIn();
        isClickPauseButtonQuit = false;
        if(AcadeSceneInfo != null)
        {
            FindObjectOfType<AcadeManager>().isAcadeOn = true;
            Camera.main.transform.position = new Vector3(AcadeSceneInfo.GetComponent<AcadeSceneInfo>().MainSceneCameraX, 0, -10);
        }
    }
}
