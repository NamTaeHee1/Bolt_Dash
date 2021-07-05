using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcadeCameraSetting : MonoBehaviour
{
    [SerializeField] private GameObject Target;

    private void LateUpdate()
    {
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, Target.transform.position, 0.5f);
    }
}