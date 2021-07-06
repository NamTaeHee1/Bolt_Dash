using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlateControl : MonoBehaviour
{
    Rigidbody2D PlateRigidbody;

    SpriteRenderer PlateSpriteRenderer;

    DanielLochner.Assets.SimpleScrollSnap.ColorInfo ObjectColor;

    bool isStepOn = false;

    [SerializeField] GameObject LeftUpRayCast, MiddleUpRayCast, RightUpRayCast;
    [SerializeField] GameObject LeftRayCast, RightRayCast;
    [SerializeField] GameObject LeftDownRayCast, MiddleDownRayCast, RightDownRayCast;

    [SerializeField] Collider2D[] PlateColliders;

    private void Awake()
    {
        ObjectColor = DanielLochner.Assets.SimpleScrollSnap.StoreManager.InGameObjectColor;
        PlateRigidbody = GetComponent<Rigidbody2D>();
        PlateSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        PlateSpriteRenderer.color = new Color32(ObjectColor.CircleColor.r, ObjectColor.CircleColor.g, ObjectColor.CircleColor.b, 140);
    }

    public void CheckAfterJump()
    {
        StartCoroutine(CheckToStepOnJumpPlate());
    }

    IEnumerator CheckToStepOnJumpPlate()
    {
        float Timer = 0;
        while (true)
        {
            Timer += Time.deltaTime;
            if (Timer >= 3.0f)
                yield return null;
            Debug.DrawRay(MiddleUpRayCast.transform.position, new Vector2(0, 5), Color.red, 3.0f);
            if (Physics2D.Raycast(MiddleUpRayCast.transform.position, Vector2.up, 3.0f, LayerMask.GetMask("Player")) ||
                Physics2D.Raycast(LeftUpRayCast.transform.position, Vector2.up, 3.0f, LayerMask.GetMask("Player")) ||
                Physics2D.Raycast(RightUpRayCast.transform.position, Vector2.up, 3.0f, LayerMask.GetMask("Player")))
            {
                for (int i = 0; i < PlateColliders.Length; i++)
                    PlateColliders[i].isTrigger = false;
            }

            if (Physics2D.Raycast(LeftRayCast.transform.position, Vector2.left, 3.0f, LayerMask.GetMask("Player")) ||
                Physics2D.Raycast(RightRayCast.transform.position, Vector2.right, 3.0f, LayerMask.GetMask("Player")) ||
                Physics2D.Raycast(LeftDownRayCast.transform.position, Vector2.down, 3.0f, LayerMask.GetMask("Player")) ||
                Physics2D.Raycast(MiddleDownRayCast.transform.position, Vector2.left, 3.0f, LayerMask.GetMask("Player")) ||
                Physics2D.Raycast(RightDownRayCast.transform.position, Vector2.left, 3.0f, LayerMask.GetMask("Player")))
            {
                for (int i = 0; i < PlateColliders.Length; i++)
                    PlateColliders[i].isTrigger = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
          {
            PlateSpriteRenderer.color = ObjectColor.CircleColor;
            if (!isStepOn)
                StartCoroutine(ActiveGravity());
            isStepOn = true;
          }
    }
    
    IEnumerator ActiveGravity()
    {
        yield return null;
    }
}
