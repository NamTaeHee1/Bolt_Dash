using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    Transform tr;
    Vector3 Target;
    Vector3 BeforeTarget;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        BeforeTarget = new Vector3(0, 3.5f, 0);
        Target = new Vector3(0, -1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        tr.position = Vector3.Lerp(tr.position, BeforeTarget, 0.001f);
        tr.position = Vector3.Lerp(tr.position, Target, 0.01f);
    }

}
