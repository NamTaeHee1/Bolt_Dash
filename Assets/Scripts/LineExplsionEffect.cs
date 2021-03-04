using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineExplsionEffect : MonoBehaviour
{
    [SerializeField] private GameObject Prefab = null;
    [SerializeField] private float e_Force = 0f;
    [SerializeField] Vector3 offset = Vector3.zero;
    void Start() => Explosion();

    void Explosion()
    {
        Debug.Log("Äç");
    }
}
