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

    [Header("Booleans")]
    private bool onHurt;
    private bool onShooting;

    
        
    [Header("Collision")]
    private float collisionRadius = 0.15f;//碰撞半径
    private Vector2 bottomOffset, rightOffset, leftOffset;//下左右相对于角色中心的二维向量
    private Collider2D coll;//角色的碰撞器

    
    private float face = 1;//角色朝向，初始朝向向右边
    private float HP = 100f;//角色血量
    public GameObject weapon;//调用武器


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
        if(moveInput.x>0)
            {
                spriteRenderer.flipX = false;
                
                gameObject.BroadcastMessage("IsFacingRight", true);
            }
        if(moveInput.x<0)
            {
                spriteRenderer.flipX = true;
                
                gameObject.BroadcastMessage("IsFacingRight", false);
            }
    }

    void Hurt(Collision2D collision)//受伤代码
    {
        onHurt = true;
        AccordingDirectionFlip(collision);
    }

    void Start()
    {
        coll = GetComponent<Collider2D>();//获取角色碰撞器
        weapon= GameObject.Find("Gun");//获取枪
        
        onShooting = false;//初始不在射击
        onHurt = false;//初始不受伤
    }

    void Flip()//反转
    {
        transform.Rotate(0f,180f,0f);//这样枪口一起转向
    }

    void AccordingDirectionFlip(Collision2D collision)//根据敌人方向，安排玩家转向
    {
        if (collision != null)//如果玩家出现视野中
        {
            int direction;
            if (collision.transform.position.x < transform.position.x)
            {
                direction = -1;//玩家在敌人的左边
            }
            else
            {
                direction = 1;//玩家在敌人的右边
            }
            if (direction != face)//表示方向不一致
            {
                //Debug.Log(direction);
                Flip();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            HP -= 25f;//碰到一次敌人减去25血量
            
            Hurt(collision);
        }
    }

    bool isShooting()//判断是否射击
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            onShooting=(onShooting == true)? false : true ;
            Debug.Log(onShooting);
        }
        return onShooting;
    }

    void shoot(float moveMultiple, float faceDirection)
    {
        weapon.GetComponent<Weapon>().Shoot();
    }
    
   
    
    
    

}
