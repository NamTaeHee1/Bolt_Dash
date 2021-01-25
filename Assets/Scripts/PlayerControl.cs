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
        if(Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(UnBeatTime());
        }

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

    IEnumerator UnBeatTime()
    {
        int countTime = 0;

        while(countTime < 10)
        {
            if (countTime % 2 == 0)
                this.gameObject.GetComponent<SpriteRenderer>().color = new Color32(0, 255, 105, 90);
            else
                this.gameObject.GetComponent<SpriteRenderer>().color = new Color32(0, 255, 105, 180);

            yield return new WaitForSeconds(0.2f);

            countTime++;
        }

        this.gameObject.GetComponent<SpriteRenderer>().color = new Color32(0, 255, 105, 255);

        yield return null;
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
