using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcadeCameraSetting : MonoBehaviour
{
    [SerializeField] private GameObject Target;
    private Transform CameraTransform;

    void Start() => CameraTransform = GetComponent<Transform>();

    void Update()
    {
        CameraTransform.position = new Vector3(0, Target.GetComponent<Transform>().position.y, -10);
    }
}