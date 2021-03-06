using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateControl : MonoBehaviour
{
    Transform PlateTr;
    SpriteRenderer PlateSR;
    ObjectColor PlateColor = new ObjectColor();
    [SerializeField]
    SpriteRenderer[] PlatePart;
    Color32 MountingColor;
    void Start()
    {
        PlateTr = GetComponent<Transform>();
        PlateSR = GetComponent<SpriteRenderer>();
        MountingColor = PlateColor.GetInGameColor();
        PlateSR.color = new Color32(MountingColor.r, MountingColor.g, MountingColor.b, 140);
        for (int i = 0; i < PlatePart.Length; i++)
            PlatePart[i].color = new Color32(MountingColor.r, MountingColor.g, MountingColor.b, 140);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlateSR.color = MountingColor;
            for (int i = 0; i < PlatePart.Length; i++)
                PlatePart[i].color = MountingColor;
        }
    }

}
