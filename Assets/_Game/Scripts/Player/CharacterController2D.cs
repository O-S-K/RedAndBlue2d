using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using System;




[RequireComponent(typeof(Rigidbody2D))]
[ExecuteInEditMode]
sealed public class CharacterController2D : MonoBehaviour
{

    [Header("Anination")]
    AnimationHandle animationHandle;
    [SpineAnimation] public string idle;
    [SpineAnimation] public string idleMagnet;

    [SpineAnimation] public string run;
    [SpineAnimation] public string runMagnet;

    [SpineAnimation] public string jump;
    [SpineAnimation] public string jumpMagnet;
    [SpineAnimation] public string victory;
    [SpineAnimation] public string wavehand;
    [SpineAnimation] public string dead;
    [SpineAnimation] public string push;




    //Move
    [Header("Movement")]
    public Vector2 dir;
    // The speed at which the character moves
    public float speed = 10f;

    // The force applied when the character jumps
    public float jumpForce = 10f;
    public float delayJump = 0.5f;
    public float limitX = 3;
    // A reference to the character's Rigidbody2D component
    public Rigidbody2D rb;

    // The layer mask for the ground layer
    public LayerMask groundLayer;
    public LayerMask boxObstanceLayer;


    public bool isGrounded = true;
    public bool isBoxLeft = false;
    public bool isBoxRight = false;


    // A flag to track whether or not the character is facing right
    public bool isFacingRight = true;
    public bool isUpdate = false;
    public bool isOpenDoor = false;
    [Header("Box Collider")]
    public Vector2 sizeBox;
    public Vector2 offsetBox;
    [Space(5)]
    public Vector2 sizeBoxLeft;
    public Vector2 offsetBoxLeft;
    [Space(5)]
    public Vector2 sizeBoxRight;
    public Vector2 offsetBoxRight;
    private void Reset()
    {
        if (isFacingRight)
        {
            transform.localScale = new Vector3(-1, 1, 1);

        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
    void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();

        // Get the Animator component
    }

    public void Init(AnimationHandle ani)
    {
        animationHandle = ani;
        isGrounded = true;
        isFacingRight = true;
        animationHandle.PlayAnimation(idle, 0.1f, 0, true);

    }
    private void Update()
    {
        if (!isUpdate) return;
        CheckGround();
        CheckObsBox();
        AnimationHandle();

    }
    public void Dead()
    {
        isUpdate = false;
        animationHandle.PlayAnimation(dead, 0.1f, 0, false, true);
    }

    private void FixedUpdate()
    {
        if (!isUpdate) return;

        Movement();

    }
    void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position + (Vector3)offsetBox, sizeBox, 90, groundLayer);
        isGrounded = colliders.Length >= 1;
        // foreach (var item in colliders)
        // {
        //     Debug.Log("name " + item.name);
        // }
    }
    void CheckObsBox()
    {
        //check left
        Collider2D[] collidersLeft = Physics2D.OverlapBoxAll(transform.position + (Vector3)offsetBoxLeft, sizeBoxLeft, 90, boxObstanceLayer);
        isBoxLeft = collidersLeft.Length >= 1;

        //check right
        Collider2D[] collidersRight = Physics2D.OverlapBoxAll(transform.position + (Vector3)offsetBoxRight, sizeBoxRight, 90, boxObstanceLayer);
        isBoxRight = collidersRight.Length >= 1;

    }
    public void Idle()
    {
        if (!isOpenDoor)
        {
            animationHandle.PlayAnimation(idle, 0.1f, 0, true);
        }
        else
        {
            animationHandle.PlayAnimation(wavehand, 0.1f, 0, true, true);
        }
        dir = Vector2.zero;
        rb.velocity = Vector2.zero;
        isUpdate = false;
    }
    public void SetMain()
    {
        isUpdate = true;
    }
    void AnimationHandle()
    {
        // if (dir.x == 0 && isGrounded && !isOpenDoor)
        // {
        //     animationHandle.PlayAnimation(idle, 0.1f, 0, true);
        // }
        //  if (dir.x == 0 && isGrounded && isOpenDoor)
        // {
        //     //animationHandle.PlayAnimation(wavehand, 0.1f, 0, true,true);
        // }
        if (dir.x != 0 && isGrounded)
        {
            if (!isBoxLeft && !isBoxRight)
            {
                animationHandle.PlayAnimation(run, 0.1f, 0, true);
            }
            else
            {
                animationHandle.PlayAnimation(push, 0.1f, 0, true);
            }
        }
        if (rb.velocity.y != 0 && !isGrounded)
        {
            animationHandle.PlayAnimation(jump, 0.1f, 0, true);
        }
    }
    void Movement()
    {
        rb.velocity = new Vector2(dir.x * speed, rb.velocity.y);
        if (rb.velocity.x > limitX)
        {
            rb.velocity = new Vector2(limitX, rb.velocity.y);
        }
        else if (rb.velocity.x < -limitX)
        {
            rb.velocity = new Vector2(-limitX, rb.velocity.y);
        }
        // // Flip the character if necessary
        if (dir.x != 0)
        {
            Flip(dir.x);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            if (!isOpenDoor)
                animationHandle.PlayAnimation(idle, 0.1f, 0, true);
            else
                animationHandle.PlayAnimation(wavehand, 0.1f, 0, true, true);

        }

    }
    public void Jump()
    {
        if (!isGrounded)
        {
            return;
        }

        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        // Set the isGrounded flag to false
        // Set the jumping animation
        animationHandle.PlayAnimation(jump, 0.1f, 0, true);
    }
    public void Jump(float forceHieght)
    {
     

        rb.AddForce(Vector2.up * forceHieght, ForceMode2D.Impulse);
        // Set the isGrounded flag to false
        // Set the jumping animation
        animationHandle.PlayAnimation(jump, 0.1f, 0, true);
    }
    void Flip(float dir)
    {
        // Flip the character
        if (dir > 0)
            isFacingRight = true;
        else
            isFacingRight = false;

        if (isFacingRight)
            transform.localScale = new Vector3(-1, 1, 1);
        else
            transform.localScale = new Vector3(1, 1, 1);
    }

    private void OnDrawGizmos()
    {
        if (isGrounded)
        {
            Gizmos.color = Color.green;

        }
        else
        {
            Gizmos.color = Color.red;

        }
        Gizmos.DrawWireCube(transform.position + (Vector3)offsetBox, sizeBox);

        if (isBoxLeft)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position + (Vector3)offsetBoxLeft, sizeBoxLeft);
        }
        else
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(transform.position + (Vector3)offsetBoxLeft, sizeBoxLeft);

        }


        if (isBoxRight)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position + (Vector3)offsetBoxRight, sizeBoxRight);

        }
        else
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(transform.position + (Vector3)offsetBoxRight, sizeBoxRight);

        }

    }

}