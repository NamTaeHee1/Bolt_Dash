using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcadeCameraSetting : MonoBehaviour
{
    [SerializeField] private GameObject Target;

    private void LateUpdate()
    {
        Vector3 pos = Vector3.Lerp(Camera.main.transform.position, Target.transform.position, 0.1f);
        pos.z = -10;
        Camera.main.transform.position = pos;
    }
}