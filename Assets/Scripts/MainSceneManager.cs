using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneManager : MonoBehaviour
{
    [SerializeField] AcadeSceneInfo AcadeSceneInfo;

    [SerializeField] private GameObject GameSceneReload;
    [SerializeField] private GameObject GameCanvasObject;

    private void Awake()
    {
        Destroy(GameObject.Find("[DOTween]"));
    }

    private void Start()
    {
        FadeManager.instance.FadeIn();
        if (AcadeSceneInfo.AcadeLevel.Equals(""))
        {
            FindObjectOfType<AcadeManager>().isAcadeOn = true;
            Camera.main.transform.position = new Vector3(AcadeSceneInfo.MainSceneCameraX, 0, -10);
        }
    }

    public void CreateMainSceneReloadObject()
    {
        GameObject GameSceneReloadObject = Instantiate(GameSceneReload);
        DontDestroyOnLoad(GameSceneReloadObject);
    }
}
