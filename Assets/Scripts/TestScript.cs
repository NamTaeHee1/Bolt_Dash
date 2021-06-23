using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.EventSystems;

public class TestScript : MonoBehaviour
{
    Transform tr;
    [SerializeField] float Height = 3.0f;

    private void Awake()
    {
        tr = GetComponent<Transform>();
    }

    private void Update()
    {
        Debug.DrawRay(tr.position, Vector2.up * Height, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(tr.position, Vector2.up, 3.0f);
        if (hit.collider != null)
            Debug.Log(hit.collider.name);
    }
}
