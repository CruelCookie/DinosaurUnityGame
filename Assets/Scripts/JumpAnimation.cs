using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAnimation : MonoBehaviour
{
    private Animator mAnimator;
    public static bool isGrounded = true;
    [SerializeField] GameObject groundCheckObject;
    [SerializeField] LayerMask groundLayer;

    void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckObject.transform.position, Global.groundCheckRadius, groundLayer);

        if(mAnimator != null && Input.GetKey("space") && isGrounded)
        {
                mAnimator.SetTrigger("Jump");
        }
    }
}