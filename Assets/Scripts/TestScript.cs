using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
    RectTransform rect;
    Vector2 FirstPosition, EndPosition, MovePosition;
    [SerializeField] float Speed = 2000.0f;
    void Start()
    {
        rect = GetComponent<RectTransform>();
        FirstPosition = new Vector3(0, -400, 0);
        EndPosition = new Vector3(0, 400, 0);
    }

    private void Update()
    {
        if (rect.anchoredPosition.y >= EndPosition.y)
            rect.anchoredPosition = FirstPosition;
        MovePosition += Vector2.up * 200.0f * Time.deltaTime;
        rect.anchoredPosition = MovePosition;
    }

}
