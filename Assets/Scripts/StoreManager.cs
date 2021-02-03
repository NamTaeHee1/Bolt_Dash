using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    [SerializeField]
    private GameObject StoreObject;
    private void Awake()
    {
        Invoke("ShowItem", 1.1f);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowItem()
    {
        StoreObject.SetActive(true);
    }

    public void ClickBackButton()
    {
        StoreObject.SetActive(false);
    }
}
