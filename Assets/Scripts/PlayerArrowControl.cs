using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArrowControl : MonoBehaviour
{
    [SerializeField] private float ArrowRotateSpeed = 3.0f;

    [SerializeField] private Transform ArrowTransform;

    private void Update() => RotateArrow();

    void RotateArrow()
    {
        if (ArrowTransform.eulerAngles.z >= 35 || ArrowTransform.eulerAngles.z <= -35)
            ArrowRotateSpeed *= -1;
        ArrowTransform.Rotate(Vector3.forward * ArrowRotateSpeed * Time.deltaTime);
    }
}
