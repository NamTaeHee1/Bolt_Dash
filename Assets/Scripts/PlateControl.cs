using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlateControl : MonoBehaviour
{
    Transform PlateTransform;
    SpriteRenderer PlateSR;
    Color32 ObjectColor;
    void Start()
    {
        PlateTransform = GetComponent<Transform>();
        PlateSR = GetComponent<SpriteRenderer>();
        ObjectColor = StoreManager.InGameObjectColor;
        Debug.Log(ObjectColor);
        PlateSR.color = new Color32(ObjectColor.r, ObjectColor.g, ObjectColor.b, 140);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Player"))
          {
            PlateSR.color = ObjectColor;
            PlateTransform.DOLocalMoveY(PlateTransform.position.y - 1, 1.0f).SetEase(Ease.InBack);
          }
    }
}
