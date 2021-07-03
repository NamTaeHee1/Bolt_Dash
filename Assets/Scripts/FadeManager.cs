using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeManager : MonoBehaviour
{
    public static FadeManager instance = null;

    [SerializeField] private Animator BlackScreenAnimator;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this.gameObject);
    }

    public FadeManager Instance
    {
        get
        {
            if (instance == null)
                return null;
            return Instance;
        }
    }

    public void FadeIn()
    {
        BlackScreenAnimator.Play("FadeIn", -1, 0f);
    }

    public void FadeOut()
    {
        BlackScreenAnimator.Play("FadeOut", -1, 0f);
    }
}
