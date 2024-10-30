using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private GameManager gameManager;

    private void Start() 
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if(!Global.isPaused)
        {
            transform.position += Vector3.left * Time.deltaTime * Global.gameSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(Global.DinosaurTag)) gameManager.GameOver();
    }
}