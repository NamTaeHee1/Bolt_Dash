using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeManager : MonoBehaviour
{
    private static FadeManager instance = null;

    public Animator BlackScreenAnimator;

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

    public static void FadeIn()
    {
        
    }

    public static void FadeOut()
    {

    }
}
