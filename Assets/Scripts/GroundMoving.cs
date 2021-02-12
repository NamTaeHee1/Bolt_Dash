using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMoving : MonoBehaviour
{
    Transform ObjectTransform;
    [SerializeField]
    private float MoveSpeed = 3.0f;

    private void Start()
    {
        ObjectTransform = GetComponent<Transform>();
    }
    void Update()
    {
        ObjectTransform.Translate(Vector2.down * MoveSpeed * Time.deltaTime);
    }
}
