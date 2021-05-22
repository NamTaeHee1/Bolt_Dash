using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.EventSystems;

public class TestScript : MonoBehaviour
{
    public void Button_Click()
    {
        Debug.Log(EventSystem.current.currentSelectedGameObject);
    }
}
