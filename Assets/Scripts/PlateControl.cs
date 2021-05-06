using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlateControl : MonoBehaviour
{
    Transform PlateTransform;
    SpriteRenderer PlateSR;
    Color32 ObjectColor;
    bool isStepOn = false;
    void Start()
    {
        PlateTransform = GetComponent<Transform>();
        PlateSR = GetComponent<SpriteRenderer>();
        ObjectColor = DanielLochner.Assets.SimpleScrollSnap.StoreManager.InGameObjectColor;
        PlateSR.color = new Color32(ObjectColor.r, ObjectColor.g, ObjectColor.b, 140);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Player"))
          {
            PlateSR.color = ObjectColor;
            if(!isStepOn)
                PlateTransform.DOLocalMoveY(PlateTransform.position.y + 0.05f, 0.3f).SetEase(Ease.InBack, 10);
            isStepOn = true;
          }
    }
}
