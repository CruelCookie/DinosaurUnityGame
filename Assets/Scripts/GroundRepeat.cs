using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    Vector3 StartPos;
    float RepeatWidth;

    void Start()
    {
        StartPos = transform.position;
        RepeatWidth = GetComponent<BoxCollider2D>().size.x/2;
    }

    void Update()
    {
        if(transform.position.x < StartPos.x - RepeatWidth)
        {
            transform.position = StartPos;
        }
    }
}
