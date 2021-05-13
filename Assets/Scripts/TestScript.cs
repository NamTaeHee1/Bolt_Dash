using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class TestScript : MonoBehaviour
{
    [SerializeField] private GameObject RedSquare;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) SquareMove();
    }

    void SquareMove()
    {
        RedSquare.GetComponent<RectTransform>().DOAnchorPosY(-5.0f, 1.0f);
    }
}
