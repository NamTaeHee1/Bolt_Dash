using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraViewCanvasControl : MonoBehaviour
{
    public CameraViewCanvasControl Instance = null;

    private void Awake()
    {
        if (Instance = null)
        {
            Instance = this;
            DontDestroyOnLoad(this.Instance);
        }
        else
            Destroy(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
