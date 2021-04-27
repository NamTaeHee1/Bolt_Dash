using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArrowControl : MonoBehaviour
{
    Transform ArrowTransform;
    [SerializeField] private GameObject ArrowObject;
    [SerializeField] private float ArrowRotateSpeed = 3.0f; 

    void Start() => ArrowTransform = ArrowObject.GetComponent<Transform>();

    void FixedUpdate() => ArrowRotate();

    void ArrowRotate()
    {
        if (ArrowTransform.rotation.z >= 0.3f)
        {
            ArrowRotateSpeed *= -1;
            Debug.Log("��������");
        }
        else if (ArrowTransform.rotation.z <= -0.3f)
        {
            ArrowRotateSpeed *= -1;
            Debug.Log("����������");
        }
        ArrowTransform.RotateAround(GetComponentInParent<Transform>().position, Vector3.forward, Time.deltaTime * ArrowRotateSpeed);
    }
}