using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcadeManager : MonoBehaviour
{
    public bool isAcadeOn = false;
    Vector3 TargetPosition = new Vector3(5.62f, 0, 0);
    Vector3 CurrentPosition = new Vector3(0, 0, 0);
    Transform CameraTransform;

    private void Start()
    {
        CameraTransform = Camera.main.GetComponent<Transform>();
    }

    void Update()
    {
        if (isAcadeOn)
            CameraTransform.position = Vector3.Lerp(CameraTransform.position, TargetPosition, 0.02f);
    }
}
