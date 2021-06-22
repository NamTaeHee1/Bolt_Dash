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

        [SerializeField] private SpriteRenderer PlayerSpriteRenderer;

        ColorInfo PlayerColor = StoreManager.CharacterColor;

        private void Start() => PlayerSpriteRenderer.color = PlayerColor.CircleColor;

        public void PlayerJump()
        {
            Vector3 ArrowRotation = FindObjectOfType<PlayerArrowControl>().GetArrowAngle();
            int JumpPower = FindObjectOfType<PlayerArrowControl>().GetJumpPower();
            PlayerRigid.AddForce(ArrowRotation *  JumpPower * 4.5f, ForceMode2D.Impulse);
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