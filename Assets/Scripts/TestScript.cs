using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    Transform tr;
    Vector3 Target;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        Target = new Vector3(0, -1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
            tr.position = Vector3.Lerp(tr.position, Target, 0.01f);
    }
}
