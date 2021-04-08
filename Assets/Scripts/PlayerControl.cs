using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Transform PlayerTransform;
    private Rigidbody2D PlayerRigid;
    private Transform ArrowTransform;

    [SerializeField] private float JumpHeight = 5.0f;

    private void Start()
    {
        PlayerRigid = GetComponent<Rigidbody2D>();
        ArrowTransform = GameObject.Find("PlayerArrow").GetComponent<Transform>();
    }

    private void Update()
    {
        PlayerJump();
    }

    public void PlayerJump()
    {
        if(Input.GetMouseButtonDown(0))
          {
            Debug.Log("Click");
            PlayerTransform.rotation = ArrowTransform.rotation;
            PlayerRigid.AddForce(Vector2.up * JumpHeight, ForceMode2D.Impulse);
          }
    }
}
