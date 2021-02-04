using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageAnimationControl : MonoBehaviour
{
    Transform tr;
    public enum WILLMOVING { POSITION, SCALE };
    public enum DIRECTION { HORIZONTAL, VERTICAL };
    [SerializeField]
    float Speed = 10.0f;
    [SerializeField]
    WILLMOVING WillMoving;
    [SerializeField]
    DIRECTION Direction;
    public Vector3 StartPosition;
    public Vector3 EndPosition;
    public float EndScale;

    private void Start()
    {
        tr = GetComponent<Transform>();
    }

    void Update()
    {
        if(WillMoving == WILLMOVING.POSITION)
        {
                tr.position = Vector2.MoveTowards(StartPosition, EndPosition, Speed);
        }
        else
        {
            Debug.Log("Scale");
            if (Direction == DIRECTION.HORIZONTAL)
            {
                while(tr.localScale.x <= EndScale)
                {
                    float growX = tr.localScale.x + Time.deltaTime;
                    tr.localScale = new Vector3(transform.localScale.x, growX, transform.localScale.z);
                }
            }
            else
            {
                while (tr.localScale.y <= EndScale)
                {
                    float growY = tr.localScale.y + Time.deltaTime;
                    tr.localScale = new Vector3(transform.localScale.x, growY, transform.localScale.z);
                }
            }
        }
    }
}
