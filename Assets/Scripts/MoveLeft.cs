using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float InitialGameSpeed = 5;

    private void Start()
    {
        Global.gameSpeed = InitialGameSpeed;
    }

    void Update()
    {  
        if(!Global.isPaused) 
        {
            Move();
            Global.gameSpeed += Global.SpeedIncrease * Time.deltaTime;
        }
    }

    private void Move()
    {
        transform.Translate(Vector3.left * Time.deltaTime * Global.gameSpeed);
    }
}
