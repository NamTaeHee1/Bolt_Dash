using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AcadeManager : MonoBehaviour
{
    public bool isAcadeOn = false;
    [SerializeField]    Vector3 MovingPosition = new Vector3(5.62f, 0, -10);
    Transform CameraTransform;
    [SerializeField]    float CameraSpeed = 0.06f;
    [SerializeField]    Button[] Buttons;
    [SerializeField]    public int AcadeLevel = 0;
    [SerializeField]    GameObject[] PowerSocketLines;
    [SerializeField]    GameObject[] PowerSocketLineButtons;
    [SerializeField]    Button BackToMain;
    [SerializeField]    Button[] PositionMoveButtons;
    bool isReadyShowNextStage = false;

    void Start() => CameraTransform = Camera.main.GetComponent<Transform>();

    void Update()
    {
        CheckShouldShowButton();
        if (isAcadeOn)
        {
            CameraTransform.position = Vector3.Lerp(CameraTransform.position, MovingPosition, CameraSpeed);

            StartCoroutine(WaitShowNextStage());
            BackToMain.interactable = false;
            if (isReadyShowNextStage)
            {
                PowerSocketLines[AcadeLevel].SetActive(true);
                PowerSocketLineButtons[AcadeLevel].SetActive(true);
                isReadyShowNextStage = false;
            }
        }
    }

    void CheckShouldShowButton()
    {
        if (AcadeLevel >= 6)
        {
            PositionMoveButtons[2].gameObject.SetActive(true);
            PositionMoveButtons[3].gameObject.SetActive(true);
        }
        else if (AcadeLevel >= 3)
        {
            PositionMoveButtons[0].gameObject.SetActive(true);
            PositionMoveButtons[1].gameObject.SetActive(true);
        }
        
    }

    public void ClickBackToMain()
    {
        MovingPosition = new Vector3(0, 0, -10);
        for (int i = 0; i < 4; i++)
            Buttons[i].interactable = true;
    }

    public void ClickAcade()
    {
        isAcadeOn = true;
        MovingPosition = new Vector3(5.62f, 0, -10);
    }

    IEnumerator WaitShowNextStage()
    {
        yield return new WaitForSeconds(0.6f);
        BackToMain.interactable = true;
        isReadyShowNextStage = true;
    }
}
