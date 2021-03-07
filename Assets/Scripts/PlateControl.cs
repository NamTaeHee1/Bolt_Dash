using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateControl : MonoBehaviour
{
    Transform PlateTr;
    SpriteRenderer PlateSR;
    Color32 MountingColor;
    [SerializeField]
    public AnimationCurve StepOnAnimation;
    [SerializeField]
    float AnimationTime = 2.0f;
    bool isStepON = false;
    void Start()
    {
        PlateTr = GetComponent<Transform>();
        PlateSR = GetComponent<SpriteRenderer>();
        MountingColor = StoreManager.InGameObjectColor;
        PlateSR.color = new Color32(MountingColor.r, MountingColor.g, MountingColor.b, 140);
    }

    private void Update()
    {
        if(isStepON)
            PlateStopOnAnimation();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlateSR.color = MountingColor;
            isStepON = true;
        }
    }

    void PlateStopOnAnimation()
    {
        StepOnAnimation.Evaluate(AnimationTime);
    }

}
