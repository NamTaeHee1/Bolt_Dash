using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DanielLochner.Assets.SimpleScrollSnap
{
    public class PlayerControl : MonoBehaviour
    {
       private Transform PlayerTransform;
        [SerializeField] private Transform ArrowTransform;

        [SerializeField] private Rigidbody2D PlayerRigid;

        [SerializeField] private GameObject Arrow;

       private SpriteRenderer PlayerSpriteRenderer;

        private void Awake()
        {
            PlayerTransform = GetComponent<Transform>();
            PlayerSpriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start() => PlayerSpriteRenderer.color = StoreManager.CharacterColor.CircleColor;

        public void PlayerJump()
        {
            Vector3 ArrowRotation = FindObjectOfType<PlayerArrowControl>().GetArrowAngle();
            float JumpPower = FindObjectOfType<PlayerArrowControl>().GetJumpPower();
            PlayerRigid.AddForce(ArrowRotation *  JumpPower, ForceMode2D.Impulse);
            FindObjectOfType<PlateControl>().CheckAfterJump();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.name.Equals("RightWall"))
                PlayerRigid.AddForce(Vector2.left * 3.0f, ForceMode2D.Impulse);
            else if (collision.gameObject.name.Equals("LeftWall"))
                PlayerRigid.AddForce(Vector2.right * 3.0f, ForceMode2D.Impulse);
        }
    }

}