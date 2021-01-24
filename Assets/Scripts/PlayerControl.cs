using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Transform PlayerTransform;
    Rigidbody2D PlayerRigidbody;
    [SerializeField]
    private float PlayerSpeed = 3.0f;
    [SerializeField]
    private float JumpWeight = 30.0f;
    bool isJump = false;
    Color GroundBasicColor = new Color(255/255f, 255/255f, 255/255f, 255);

    private void Awake()
    {
        PlayerTransform = GetComponent<Transform>();
        PlayerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        PlayerJump();
    }

    private void FixedUpdate()
    {
        PlayerMove();
    }

    private void PlayerJump()
    {
        if(Input.GetButton("Jump") && !isJump)
        {
            isJump = true;
            PlayerRigidbody.AddForce(Vector2.up * JumpWeight, ForceMode2D.Impulse);
        }
    }

    private void PlayerMove()
    {
        float h = Input.GetAxisRaw("Horizontal");
        PlayerTransform.Translate(new Vector3(h, 0, 0) * Time.deltaTime * PlayerSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isJump = false;
            collision.gameObject.GetComponent<SpriteRenderer>().color = GroundBasicColor;
        }
    }
}
