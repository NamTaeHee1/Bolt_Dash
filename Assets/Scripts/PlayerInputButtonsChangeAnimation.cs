using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputButtonsChangeAnimation : MonoBehaviour
{
    [SerializeField] private GameObject[] Buttons;
    [SerializeField] private float MoveSpeed = 3.0f;
    [SerializeField] private List<GameObject> ButtonOrders;
    [SerializeField] private AnimationCurve AnimationValue;
    Vector3 BasicPosition = new Vector3(-2.65f, -1.22f, 0);
    bool isStarted = false;

    void Update() // 1.7 , 4
    {
        Debug.Log(AnimationValue.Evaluate(10.0f));
        if (Input.GetKeyDown(KeyCode.Space))
            isStarted = true;
        if(isStarted)
        {
            Buttons[0].GetComponent<RectTransform>().anchoredPosition += Vector2.up * MoveSpeed * Time.deltaTime;
            StartCoroutine(StartChangeButton(5.0f));
        }
        
        if (Buttons[0].GetComponent<RectTransform>().anchoredPosition.y >= 1.7f)
            Buttons[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(Buttons[0].GetComponent<RectTransform>().anchoredPosition.x, -4.0f);
    }

    IEnumerator StartChangeButton(float delayTime)
    {
        Debug.Log("빨라지기 시작");
        while (MoveSpeed <= 20.0f)
        {
            MoveSpeed += Time.deltaTime;
            yield return new WaitForSeconds(0.1f);
        }
        Debug.Log("빨라지기 끝");
        yield return new WaitForSeconds(2.0f);
        Debug.Log("느려지기 시작");
        while (MoveSpeed >= 3.0f)
        {
            MoveSpeed -= Time.deltaTime;
            yield return new WaitForSeconds(0.1f);
        }
        Debug.Log("느려지기 끝");
        isStarted = false;
        yield return null;
        //Buttons[0].GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(Buttons[0].GetComponent<RectTransform>().anchoredPosition, new Vector2(-2.65f, -1.22f), 5.0f);
    }
}
