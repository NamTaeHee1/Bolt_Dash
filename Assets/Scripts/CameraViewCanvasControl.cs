using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraViewCanvasControl : MonoBehaviour
{
    public static CameraViewCanvasControl Instance = null;

    [SerializeField] private GameObject CanvasObject;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this.gameObject);
    }

     public void SetCameraCanvasParent()
    {
        CanvasObject.transform.parent = GameObject.Find("Main Camera").gameObject.transform;
    }

    public void DontDestroyCameraCanvas()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
