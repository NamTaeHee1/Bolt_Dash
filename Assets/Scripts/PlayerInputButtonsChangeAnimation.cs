using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputButtonsChangeAnimation : MonoBehaviour
{
    [SerializeField] private GameObject[] Buttons;
    [SerializeField] private float MoveSpeed = 3.0f;
    [SerializeField] private List<GameObject> ButtonOrders;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            Buttons[0].GetComponent<RectTransform>().position += Vector3.up * Time.deltaTime * MoveSpeed;
    }

    
}
