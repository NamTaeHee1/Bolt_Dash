using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.EventSystems;

public class TestScript : MonoBehaviour
{
    [SerializeField] private Animator ButtonAnim;

    public void Button_Click()
    {
        Debug.Log(ButtonAnim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f);
    }

    public void Button_Move()
    {
        ButtonAnim.Play("Test", -1, 0f);
    }

    private void Update()
    {
        Debug.Log("normalizedTime = " + ButtonAnim.GetCurrentAnimatorStateInfo(0).normalizedTime);
    }
}
