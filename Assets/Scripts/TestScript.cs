using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
    Rigidbody2D tr;
    [SerializeField] Vector2 ForcePosition;

    void Start() => tr = GetComponent<Rigidbody2D>();

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            tr.AddForce(ForcePosition * 3.0f, ForceMode2D.Impulse);
    }
}
