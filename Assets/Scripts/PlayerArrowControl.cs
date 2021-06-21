using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArrowControl : MonoBehaviour
{
    [SerializeField] private float ArrowRotateSpeed = 3.0f;

    [SerializeField] private Transform ArrowTransform;

    [SerializeField] private GameObject[] ArrowYellowBoxParts;
    private void Start()
    {
        StartCoroutine(RotateArrow());
    }

    private void Update() => ArrowTransform.Rotate(Vector3.forward * ArrowRotateSpeed * Time.deltaTime);

    IEnumerator RotateArrow()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.8f);
            ArrowRotateSpeed *= -1;
        }
    }

    public Vector3 GetArrowAngle()
    {
        return ArrowTransform.transform.up;
    }

    public int GetJumpPower()
    {
        int ChargeCount = 0;
        for (int i = 0; i < ArrowYellowBoxParts.Length; i++)
            if (ArrowYellowBoxParts[i].activeInHierarchy) ChargeCount++;
        return ChargeCount;
    }
}