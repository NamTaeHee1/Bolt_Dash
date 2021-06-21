using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArrowControl : MonoBehaviour
{
    [SerializeField] private float ArrowRotateSpeed = 3.0f;

    [SerializeField] private Transform ArrowTransform;

    private void Start()
    {

    }

    IEnumerator RotateArrow()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.3f);
        }
    }
}

/*        if (ArrowTransform.eulerAngles.z >= 35 || ArrowTransform.eulerAngles.z <= -100)
            ArrowRotateSpeed *= -1;
        ArrowTransform.Rotate(Vector3.forward* ArrowRotateSpeed * Time.deltaTime);*/