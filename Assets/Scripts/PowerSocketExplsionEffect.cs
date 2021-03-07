using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSocketExplsionEffect : MonoBehaviour
{
    [SerializeField] private GameObject Prefab = null;
    [SerializeField] private float e_Force = 5.0f;
    int RandomX, RandomY;

    void Start() => Explosion();

    void Explosion()
    {
        Rigidbody2D[] rigid = Prefab.GetComponentsInChildren<Rigidbody2D>();

        for (int i = 0; i < rigid.Length; i++)
        {
            RandomX = (i >= (rigid.Length / 2) + 1) ? Random.Range(-7, -1) : Random.Range(1, 5);
            RandomY = Random.Range(-5, 5);
            Debug.Log("게임오브젝트 : " + rigid[i].gameObject.name + " " + "RandomVector3 : " + RandomX + ", " + RandomY + ", 0");
            rigid[i].AddForce(new Vector3(RandomX, RandomY, 0) * e_Force, ForceMode2D.Impulse);
        }
    }
}
