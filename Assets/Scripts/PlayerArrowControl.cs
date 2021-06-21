using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArrowControl : MonoBehaviour
{
    [SerializeField] private float ArrowRotateSpeed = 3.0f;

    [SerializeField] private Transform ArrowTransform;

    private void Start()
    {
        StartCoroutine(RotateArrow());
    }

    private void Update() => ArrowTransform.Rotate(Vector3.forward * ArrowRotateSpeed * Time.deltaTime);

    IEnumerator RotateArrow()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.3f);
            ArrowRotateSpeed *= -1;
        }
    }
}