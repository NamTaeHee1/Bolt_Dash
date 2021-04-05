using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
    Rigidbody2D tr;
    [SerializeField] Vector2 ForcePosition;
    Color32 Color;

    void Start() => Debug.Log(Color.a);

}
