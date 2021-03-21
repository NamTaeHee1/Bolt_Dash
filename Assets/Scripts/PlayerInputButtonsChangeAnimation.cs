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
        if (Buttons[0].GetComponent<RectTransform>().position.y > 2)
        {
            Buttons[0].GetComponent<RectTransform>().position = new Vector3(Buttons[0].GetComponent<RectTransform>().position.x,
            Buttons[0].GetComponent<RectTransform>().position.y - 4, Buttons[0].GetComponent<RectTransform>().position.z);
        }
        if (Input.GetKey(KeyCode.Space))
            Buttons[0].GetComponent<RectTransform>().position += Vector3.up * Time.deltaTime * MoveSpeed;
    }

    
}
