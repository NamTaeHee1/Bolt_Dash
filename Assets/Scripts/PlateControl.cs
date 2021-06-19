using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlateControl : MonoBehaviour
{
    Transform PlateTransform;
    SpriteRenderer PlateSpriteRenderer;
    bool isStepOn = false;

    void Start()
    {
        PlateTransform = GetComponent<Transform>();
        PlateSpriteRenderer = GetComponent<SpriteRenderer>();
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
