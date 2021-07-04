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
        float zValue = ArrowTransform.eulerAngles.z;

        if(zValue == 360)
        {
            zValue = 0;
        }
        if (zValue > 180)
        {
            zValue = 360 - zValue;
        }

        if (zValue > 45)
         {
             float fixedZ = 45f;
             ArrowRotateSpeed *= -1;

            if(ArrowTransform.eulerAngles.z < 180)
               {
               fixedZ = 45f;
               }
            else if (ArrowTransform.eulerAngles.z > 180)
               {
               fixedZ = -45f;
               }
            ArrowTransform.eulerAngles = new Vector3(ArrowTransform.eulerAngles.x, ArrowTransform.eulerAngles.y, fixedZ);
          }
        ArrowTransform.Rotate(Vector3.forward * ArrowRotateSpeed * Time.deltaTime);
    }

    public Vector3 GetArrowAngle()
    {
        return ArrowTransform.transform.up;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
/*        if (collision.gameObject.name.Equals("LeftRotationLimit") || collision.gameObject.name.Equals("RightRotationLimit"))
            ArrowRotateSpeed *= -1;*/
    }

    public float GetJumpPower()
    {
        return ChargeCount * 2.0f;
    }
}