using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // 控制角色
        Rigidbody2D rb;
    //输入
        Vector2 moveInput;

        
    //移动速度
    public float moveSpeed;

    SpriteRenderer spriteRenderer;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
       
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        
    }

    private void FixedUpdate()
    {
        rb.AddForce(moveInput * moveSpeed);
        
    
    }

    
    
}
