using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerInputButtonsChangeAnimation : MonoBehaviour
{
    [SerializeField] private GameObject[] Buttons;
    [SerializeField] int SpineCount = 0;
    [SerializeField] int CurrentSpineCount = 0;
    Vector3 BasicPosition = new Vector3(-2.65f, -1.22f, 0);
    bool isStarted = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            isStarted = true;
        if(isStarted)
        {
            StartCoroutine(StartChangeButton());
            isStarted = false;
        }

    }

    IEnumerator StartChangeButton()
    {
        for (int i = 0; i < Buttons.Length; i++)
            Buttons[0].GetComponent<Button>().interactable = false;
        Buttons[0].GetComponent<RectTransform>().DOAnchorPosY(1.7f, 1.0f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(1.0f);
        Buttons[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(Buttons[0].GetComponent<RectTransform>().anchoredPosition.x, -4f);
        Buttons[0].GetComponent<RectTransform>().DOAnchorPosY(1.7f, 1.0f).SetLoops(SpineCount, LoopType.Restart);

    }
}
