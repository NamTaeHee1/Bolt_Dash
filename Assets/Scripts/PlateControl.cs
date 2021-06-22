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

    RaycastHit2D LeftRayCastHit;
    RaycastHit2D MiddleRayCastHit;
    RaycastHit2D RightRayCastHit;

    private void Awake()
    {
        ObjectColor = DanielLochner.Assets.SimpleScrollSnap.StoreManager.InGameObjectColor;
        PlateTransform = GetComponent<Transform>();
        PlateSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        Debug.Log(string.Format("»ö±ò ÀÌ¸§ : {0}, »ö±ò : {1}", ObjectColor.ColorNameText, ObjectColor.CircleColor));
        PlateSpriteRenderer.color = new Color32(ObjectColor.CircleColor.r, ObjectColor.CircleColor.g, ObjectColor.CircleColor.b, 140);
    }

    private void Update()
    {
        CheckToStepOnJumpPlate();
    }

    void CheckToStepOnJumpPlate()
    {
        LeftRayCastHit = Physics2D.Raycast(LeftRayCast.transform.position, Vector2.up, 2.0f);
        Debug.DrawRay(LeftRayCast.transform.position, Vector2.up * 2.0f, Color.red, 0.3f);
        MiddleRayCastHit = Physics2D.Raycast(MiddleRayCast.transform.position, Vector2.up, 2.0f);
        Debug.DrawRay(MiddleRayCast.transform.position, Vector2.up * 2.0f, Color.red, 0.3f);
        RightRayCastHit = Physics2D.Raycast(RightRayCast.transform.position, Vector2.up, 2.0f);
        Debug.DrawRay(RightRayCast.transform.position, Vector2.up * 2.0f, Color.red, 0.3f);
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
