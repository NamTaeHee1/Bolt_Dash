using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerSocketLineButtonInfo : MonoBehaviour
{
    private Image StageButtonImage;

    private SpriteRenderer StageSpriteRenderer;

    public TextMeshProUGUI StageButtonText;

    [SerializeField] private bool isAchieve = false;

    [SerializeField] private Color32 ChangeColor = new Color32(255, 255, 255, 0);
    [SerializeField] private Color32 BasicColor = new Color32(255, 255, 255, 255);

    private void Awake()
    {
        StageButtonImage = this.gameObject.GetComponent<Image>();
        StageButtonText = this.gameObject.GetComponentInChildren<TextMeshProUGUI>();
        StageSpriteRenderer = this.gameObject.GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        if(!isAchieve)
            StartCoroutine(ShowButtonFlicker());
    }

    IEnumerator ShowButtonFlicker()
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < 3; i++)
        {
            StageButtonImage.color = ChangeColor;
            StageButtonText.color = ChangeColor;
            StageSpriteRenderer.color = new Color32(0, 0, 0, 0);
            yield return new WaitForSeconds(0.5f);
            StageButtonImage.color = BasicColor;
            StageButtonText.color = BasicColor;
            StageSpriteRenderer.color = new Color32(0, 0, 0, 255);
            yield return new WaitForSeconds(0.5f);
        }
    }

}
