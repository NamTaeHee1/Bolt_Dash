using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlateControl : MonoBehaviour
{
    [SerializeField] Transform PlateTransform;
    [SerializeField] SpriteRenderer PlateSpriteRenderer;
    DanielLochner.Assets.SimpleScrollSnap.ColorInfo ObjectColor = DanielLochner.Assets.SimpleScrollSnap.StoreManager.InGameObjectColor;
    bool isStepOn = false;

    private void Awake()
    {
        PlateSpriteRenderer.color = new Color(ObjectColor.CircleColor.a, ObjectColor.CircleColor.g, ObjectColor.CircleColor.b, 140);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Player"))
          {
            if(!isStepOn)
                PlateTransform.DOLocalMoveY(PlateTransform.position.y + 0.05f, 0.3f).SetEase(Ease.InBack, 10);
            isStepOn = true;
          }
    }
}
