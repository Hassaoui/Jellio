using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingEnemies : MonoBehaviour
{

    public float SpeedEnnemie = 3f;
    public float CoterDeBase = 1f;
    public Transform turnLeftPoint;
    public Transform TurnRightPoint;
    public bool IsPeach = false;
    public bool IsCandyCane = false;
    public float deplacementjumpForce = 2f;
    public Transform groundCheck;
    public float checkRadius = 0.8f;
    public LayerMask WhatIsGround;
    public float pointDeTurn = 1f;
    public bool littleOne = false;


    //private
    private float moveInput;
    private Rigidbody2D rb;
    private Animator mAnimator = null;
    private bool facingRight = true;
    private bool canFlipRight = false;
    private bool canFlipLeft = true;
    private bool isGrounded = false;
    private Vector3 dir;


    void Start()
    {
        int ra = Random.Range(1, 3);
        if (littleOne)
		{
            turnLeftPoint = GameObject.Find("TurnLeftLittle").GetComponent<Transform>();
            TurnRightPoint = GameObject.Find("TurnRightLittle").GetComponent<Transform>();
            if (ra == 1)
            {
                moveInput = 1;
            }
            else if (ra == 2)
            {
                moveInput = -1;
                Flip();
                canFlipRight = true;
                canFlipLeft = false;
            }
		}
        if(!littleOne)
            moveInput = CoterDeBase;
        rb = GetComponent<Rigidbody2D>();
        mAnimator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, WhatIsGround);
        mouvement();
        
    }

    void mouvement()
	{
       
        if (Vector2.Distance(transform.position, turnLeftPoint.position) <= pointDeTurn)
        {
            moveInput = -1f;
            if(IsPeach)
                mAnimator.SetBool("goingLeft", true);
			if (IsCandyCane)
			{
				if (canFlipLeft)
				{
                    Flip();
                    canFlipRight = true;
                    canFlipLeft = false;
                }
            }
        }

        if (Vector2.Distance(transform.position, TurnRightPoint.position) <= pointDeTurn)
        {
            moveInput = 1f;
            if(IsPeach)
                mAnimator.SetBool("goingLeft", false);
			if (IsCandyCane)
			{
				if (canFlipRight)
				{
                    Flip();
                    canFlipLeft = true;
                    canFlipRight = false;
                }
            }


        }
        dir = new Vector3(moveInput, 0, 0);
        transform.position += dir * SpeedEnnemie * Time.deltaTime;

		if (IsCandyCane && isGrounded)
		{
            rb.velocity = Vector2.up * deplacementjumpForce;
            mAnimator.SetBool("InAir", false);

        }
        if(rb.velocity.y < -.1 && !IsPeach)
        {
            mAnimator.SetBool("InAir", true);
        }

    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

}
