using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectColor : MonoBehaviour
{
    public Color32 CharacterColor;

    public void SetCharacterColor(Color32 Color)
    {
        CharacterColor = Color;
    }

    public Color32 GetCharacterColor()
    {
        return CharacterColor;
    }

    public Color32 InGameColor = new Color32(255, 0, 0, 255);

    public void SetInGameColor(Color32 Color)
    {
        InGameColor = Color;
    }

    public Color32 GetInGameColor()
    {
        return InGameColor;
    }
}
