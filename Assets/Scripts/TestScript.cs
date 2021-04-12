using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
    Vector2 MousePosition;
    Transform tr;
    Rigidbody2D rigid;

    void Start()
    {
        tr = GetComponent<Transform>();
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float Angle = Mathf.Atan2(MousePosition.y - tr.position.y, MousePosition.x - tr.position.x) * Mathf.Rad2Deg;
        tr.rotation = Quaternion.AngleAxis(Angle - 90, Vector3.forward);
        if (Input.GetMouseButtonDown(0))
            rigid.AddForce(Vector2.up * 3.0f, ForceMode2D.Impulse);
    }
}
