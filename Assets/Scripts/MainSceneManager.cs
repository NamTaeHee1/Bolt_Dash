using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneManager : MonoBehaviour
{
    private GameObject AcadeSceneInfo;

    private void Awake()
    {
        AcadeSceneInfo = GameObject.Find("AcadeSceneInfo") != null ? GameObject.Find("AcadeSceneInfo").gameObject : null;
    }

    private void Start()
    {
        
    }
}
