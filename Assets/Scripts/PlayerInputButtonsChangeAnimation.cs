using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerInputButtonsChangeAnimation : MonoBehaviour
{
    [SerializeField] private GameObject[] Buttons;
    bool isStarted = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            isStarted = true;
        if(isStarted)
        {
            isStarted = false;
        }

    }

}
