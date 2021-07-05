using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcadeCameraSetting : MonoBehaviour
{
    [SerializeField] private GameObject Target;

    private void LateUpdate()
    {
        Vector3 CameraPosition = Camera.main.transform.position;
    }
}