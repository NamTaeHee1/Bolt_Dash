using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArrowControl : MonoBehaviour
{
    [SerializeField] private float ArrowRotateSpeed = 3.0f;

    [SerializeField] private Transform ArrowTransform;

    private void Update()
    {
        
    }

    void RotateArrow()
    {
        if (ArrowTransform.eulerAngles.z >= 60 || ArrowTransform.eulerAngles.z <= -60)
            ArrowRotateSpeed *= -1;
    }
}
