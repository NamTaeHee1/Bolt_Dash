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

    private void Awake()
    {
        ObjectColor = DanielLochner.Assets.SimpleScrollSnap.StoreManager.InGameObjectColor;
        PlateTransform = GetComponent<Transform>();
        PlateSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        Debug.Log(string.Format("»ö±ò ÀÌ¸§ : {0}, »ö±ò : {1}", ObjectColor.ColorNameText, ObjectColor.CircleColor));
        PlateSpriteRenderer.color = new Color32(ObjectColor.CircleColor.a, ObjectColor.CircleColor.g, ObjectColor.CircleColor.b, 140);
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
