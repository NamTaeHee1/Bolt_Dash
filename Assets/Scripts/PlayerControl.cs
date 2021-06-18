using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DanielLochner.Assets.SimpleScrollSnap
{
    public class PlayerControl : MonoBehaviour
    {
        [SerializeField] private Transform PlayerTransform;
        [SerializeField] private Transform ArrowTransform;

        [SerializeField] private Rigidbody2D PlayerRigid;

        [SerializeField] private GameObject Arrow;

        [SerializeField] private float JumpHeight = 5.0f;

        [SerializeField] private SpriteRenderer PlayerSpriteRenderer;

        ColorInfo PlayerColor = StoreManager.CharacterColor;

        private void Start()
        {
            
        }

        public void PlayerJump()
        {
            PlayerRigid.AddForce(ArrowTransform.transform.up * JumpHeight, ForceMode2D.Impulse);
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