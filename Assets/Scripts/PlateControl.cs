using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlateControl : MonoBehaviour
{
    Transform PlateTransform;
    SpriteRenderer PlateSpriteRenderer;
    DanielLochner.Assets.SimpleScrollSnap.ColorInfo ObjectColor;
    bool isStepOn = false;

    [SerializeField] GameObject LeftRayCast;
    [SerializeField] GameObject MiddleRayCast;
    [SerializeField] GameObject RightRayCast;

    RaycastHit2D MiddleRayCastHit;

    private void Awake()
    {
        ObjectColor = DanielLochner.Assets.SimpleScrollSnap.StoreManager.InGameObjectColor;
        PlateTransform = GetComponent<Transform>();
        PlateSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        PlateSpriteRenderer.color = new Color32(ObjectColor.CircleColor.r, ObjectColor.CircleColor.g, ObjectColor.CircleColor.b, 140);
    }

    private void Update()
    {
        CheckToStepOnJumpPlate();
    }

    void CheckToStepOnJumpPlate()
    {
        if (Physics2D.Raycast(MiddleRayCast.transform.position, Vector2.up * 2.0f, 3.0f).collider.gameObject.CompareTag("Player"))
            Debug.Log("À¸¾Ç");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
          {
            PlateSpriteRenderer.color = ObjectColor.CircleColor;
            if(!isStepOn)
                PlateTransform.DOLocalMoveY(PlateTransform.position.y + 0.05f, 0.3f).SetEase(Ease.InBack, 10);
            isStepOn = true;
          }
    }
}
