using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    public GameObject Object;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ShowItem", 1.1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickBackButton()
    {

    }

    void ShowItem()
    {
        Object.SetActive(true);
    }
}
