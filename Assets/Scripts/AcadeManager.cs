using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AcadeManager : MonoBehaviour
{
    public bool isAcadeOn = false;
    [SerializeField]    Vector3 PositionOne = new Vector3(5.62f, 0, -10);
    Transform CameraTransform;
    [SerializeField]    float CameraSpeed = 0.06f;
    [SerializeField]    Button[] Buttons;
    [SerializeField]    public int AcadeLevel = 0;
    [SerializeField]    GameObject[] PowerSocketLines;
    bool isReadyShowNextStage = false;

    private void Start()
    {
        CameraTransform = Camera.main.GetComponent<Transform>();
    }

    void Update()
    {
        if (isAcadeOn)
        {
            CameraTransform.position = Vector3.Lerp(CameraTransform.position, PositionOne, CameraSpeed);
            if (isReadyShowNextStage)
                PowerSocketLines[AcadeLevel].SetActive(true);
            StartCoroutine(WaitShowNextStage());
        }

    }

    public void ClickAcadeBackClick()
    {
        Debug.Log("Click");
        PositionOne = new Vector3(0, 0, -10);
        for (int i = 0; i < 4; i++)
            Buttons[i].interactable = true;
    }

    public void ClickAcade()
    {
        isAcadeOn = true;
        PositionOne = new Vector3(5.62f, 0, -10);
    }

    IEnumerator WaitShowNextStage()
    {
            yield return new WaitForSeconds(1.5f);
            isReadyShowNextStage = true;
    }
}
