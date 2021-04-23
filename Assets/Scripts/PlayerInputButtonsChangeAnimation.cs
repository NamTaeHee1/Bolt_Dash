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
            isStarted = false;
        }

    }

}
