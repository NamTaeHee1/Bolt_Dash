using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArrowControl : MonoBehaviour
{
    [SerializeField] private float ArrowRotateSpeed = 3.0f;

    public static int ChargeCount = 0;

    [SerializeField] private Transform ArrowTransform;

    [SerializeField] private GameObject[] ArrowYellowBoxParts;

    private void Start()
    {
        ArrowTransform.rotation = Quaternion.identity;
    }

    private void Update()
    {

        ArrowTransform.Rotate(Vector3.forward * ArrowRotateSpeed * Time.deltaTime);
    }

    public Vector3 GetArrowAngle()
    {
        return ArrowTransform.transform.up;
    }

    public float GetJumpPower()
    {
        return ChargeCount * 2.0f;
    }
}