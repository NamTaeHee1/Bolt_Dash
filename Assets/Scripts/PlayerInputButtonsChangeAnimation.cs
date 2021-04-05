using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
/*        for(int i = 0; i < 2; i++)
            Buttons[i].GetComponent<RectTransform>().DOAnchorPosY(1.7f, 1.0f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(1.0f);
        while (CurrentSpineCount <= SpineCount)
        {
            for(int i = 0; i < 2; i++)
                Buttons[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(Buttons[i].GetComponent<RectTransform>().anchoredPosition.x, -3.46f);
            yield return new WaitForSeconds(0.3f);
            for(int i = 0; i < 2; i++)
                Buttons[i].GetComponent<RectTransform>().DOAnchorPosY(1.7f, 0.3f);
            CurrentSpineCount++;
        }*/
        while(true)
          {
            Buttons[0].GetComponent<RectTransform>().Translate(Vector2.up * 3.0f * Time.deltaTime);
            if (CurrentSpineCount >= SpineCount)
                break;
          }
        yield return null;
    }
}
