using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneManager : MonoBehaviour
{
    private GameObject AcadeSceneInfo = null;
    [SerializeField] private GameObject GameSceneReload;
    [SerializeField] private GameObject GameCanvasObject;

    private void Awake()
    {
        Destroy(GameObject.Find("[DOTween]"));
        AcadeSceneInfo = GameObject.Find("AcadeSceneInfo") != null ? GameObject.Find("AcadeSceneInfo").gameObject : null;
    }

    private void Start()
    {
        FadeManager.instance.FadeIn();
        if (AcadeSceneInfo != null)
        {
            FindObjectOfType<AcadeManager>().isAcadeOn = true;
            Camera.main.transform.position = new Vector3(AcadeSceneInfo.GetComponent<AcadeSceneInfo>().MainSceneCameraX, 0, -10);
        }
    }

    public void CreateMainSceneReloadObject()
    {
        GameObject GameSceneReloadObject = Instantiate(GameSceneReload);
        DontDestroyOnLoad(GameSceneReloadObject);
    }
}
