using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinosaur : MonoBehaviour
{
    private float jumpForce = 13f;
    private bool isGrounded = true;
    private bool canMove = true;

    [SerializeField] Rigidbody2D rigidbdy;
    [SerializeField] GameObject groundCheckObject;
    [SerializeField] LayerMask groundLayer;

    void Update()
    {
        if(canMove){
            Jump();
        }
    }

    private void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckObject.transform.position, Global.groundCheckRadius, groundLayer);
        if(Input.GetKey("space") && isGrounded)
        {
            rigidbdy.velocity = new Vector2(rigidbdy.velocity.x, jumpForce);
        }
    }

    public void StartMovement()
    {
        canMove = true;
    }

    public void StopMovement()
    {
        canMove = false;
    }
}