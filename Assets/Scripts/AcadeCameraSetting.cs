using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcadeCameraSetting : MonoBehaviour
{
    [SerializeField] private GameObject Target;

    private void LateUpdate()
    {
        Vector3 pos = Vector3.Lerp(Camera.main.transform.position, Target.transform.position, 0.3f);
        pos = new Vector3(0, pos.y, -10);
        Camera.main.transform.position = pos;
    }
}