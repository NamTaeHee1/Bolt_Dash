using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    Rigidbody2D[] rigid;
    [SerializeField]
    GameObject prefab;

    int RandomX, RandomY;
    void Start()
    {
        rigid = prefab.GetComponentsInChildren<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            for (int i = 0; i < rigid.Length; i++)
                rigid[i].gravityScale = 1;
            Explosion();
        }
    }

    void Explosion()
    {
        for(int i = 0; i < rigid.Length; i++)
        {
            RandomX = (i >= (rigid.Length / 2) + 1) ? Random.Range(-5, -1) : Random.Range(1, 5);
            RandomY = Random.Range(-5, 5);
            Debug.Log("게임오브젝트 : " + rigid[i].gameObject.name + " " + "RandomVector3 : " + RandomX + ", " + RandomY + ", 0");
            rigid[i].AddForce(new Vector3(RandomX, RandomY, 0) * 5.0f, ForceMode2D.Impulse);
        }    
    }

}
