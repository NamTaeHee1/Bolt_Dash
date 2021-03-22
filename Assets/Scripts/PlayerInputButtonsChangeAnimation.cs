using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputButtonsChangeAnimation : MonoBehaviour
{
    [SerializeField] private GameObject[] Buttons;
    [SerializeField] private float MoveSpeed = 3.0f;
    [SerializeField] private List<GameObject> ButtonOrders;
    Vector3 BasicPosition = new Vector3(-2.65f, -1.22f, 0);
    bool isStarted = false;

    void Update() // 1.7 , 4
    {
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
        yield return new WaitForSeconds(delayTime);
        isStarted = false;
    }
}
