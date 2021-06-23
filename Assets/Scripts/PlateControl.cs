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

    [SerializeField] GameObject LeftUpRayCast, MiddleUpRayCast, RightUpRayCast;
    [SerializeField] GameObject LeftRayCast, RightRayCast;
    [SerializeField] GameObject LeftDownRayCast, MiddleDownRayCast, RightDownRayCast;
    [SerializeField] GameObject PlateCollider;

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
        Debug.DrawRay(MiddleUpRayCast.transform.position, new Vector2(0, 5), Color.red, 3.0f);
        if (Physics2D.Raycast(MiddleUpRayCast.transform.position, Vector2.up, 3.0f,  LayerMask.GetMask("Player")) ||
            Physics2D.Raycast(LeftUpRayCast.transform.position, Vector2.up, 3.0f, LayerMask.GetMask("Player")) ||
            Physics2D.Raycast(RightUpRayCast.transform.position, Vector2.up, 3.0f, LayerMask.GetMask("Player"))) PlateCollider.SetActive(true);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
          {
            PlateSpriteRenderer.color = ObjectColor.CircleColor;
            if (!isStepOn)
                PlateTransform.DOLocalMoveY(PlateTransform.position.y + 0.05f, 0.3f).SetEase(Ease.InBack, 5);
            isStepOn = true;
          }
    }
}
