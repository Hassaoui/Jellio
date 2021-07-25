using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("movement")]
    public float moveSpeed = 5f;
    public float deplacementjumpForce = 1f;
    public float SlideTimer = 2f;
    public float slideSpeed = 2f;

    [Header("Jump")]
    public float checkRadius;
    public LayerMask WhatIsGround;
    public Transform groundCheck;
    public Transform groundCheck2;
    public float jumpforce = 100f;
    public int ExtraJumps = 2;
    public float fallMultiplier = 2.5f;

    [Header("bullet")]
    public GameObject bulletprefab;
    public Transform firePoint;
    public float tempsEntreShot = 1f;
    public float rangeBullet = 10f;

    [Header("Slap")]
    public GameObject slap;
    public Transform slapPoint;
    public float slapTimer = 1f;


    //private variable
    private int realJump;
    [HideInInspector] public bool isGrounded = false;
    private Rigidbody2D rb;
    private float moveInput = 0;
    private bool facingRight = true;
    private bool CanJump = true;
    private bool secondJump = false;
    private bool Sliding;
    private float slideTime;
    private float Slide_Dir;
    private Vector2 scaleGuy;
    private Vector2 scaleGuy2;
    private float UtilisableSpeed;
    private bool slide = false;
    private Animator mAnimator = null;
    private float tempsEntreShotUtile;
    private GameObject slaped;
    private Vector3 dir;
    private float UsableTimerSlap = 0f;
    private bool NotMP = true;



    void Start()
    {
        tempsEntreShotUtile = 0;
        UtilisableSpeed = moveSpeed;
        scaleGuy = transform.localScale;
        scaleGuy2 = scaleGuy;
        mAnimator = this.GetComponent<Animator>();
        realJump = ExtraJumps;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
       
        Shoot();
        Slap();

		
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, WhatIsGround);
        if (!isGrounded)
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck2.position, checkRadius, WhatIsGround);
        }

        if (isGrounded)
        {
            mAnimator.SetBool("AutreJump", false);
            realJump = ExtraJumps;
            CanJump = true;
            
        }

		if (slaped != null)
		{
            slaped.transform.position = slapPoint.position;
		}

        if (Input.GetKeyDown("w") && CanJump)
        {
            rb.velocity = Vector2.down * 15f;
            mAnimator.SetBool("IsJumping", true);
        }

        if (Input.GetKeyDown("w") && secondJump == true)
        {
            mAnimator.SetBool("AutreJump", true);
            secondJump = false;
        }

        if (!slide)
        {
            moveInput = Input.GetAxis("Horizontal");
            if (moveInput != 0 && isGrounded)
            {
                    rb.velocity = Vector2.up * deplacementjumpForce;
            }

            if (!facingRight && moveInput > 0)
            {
                Flip();
            }
            else if (facingRight && moveInput < 0)
            {
                Flip();
            }
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        }
        else
        {
            UtilisableSpeed = slideSpeed;
            slideTime -= Time.deltaTime;
            Slide();
            if (slideTime <= 0)
            {
                StopSlide();
            }
        }
        rb.velocity = new Vector2(UtilisableSpeed * moveInput, rb.velocity.y);
        if (Input.GetKeyDown("s") && !slide)
        {
            slide = true;
            slideTime = SlideTimer;
        }

        if(isGrounded && slide)
		{
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

    }

    void Slide()
	{
		if(moveInput < 0)
            transform.localScale = new Vector2(-1.75f,  0.25f);

        if(moveInput > 0)
            transform.localScale = new Vector2(1.75f, 0.25f);

        if(moveInput == 0 && facingRight)
            transform.localScale = new Vector2(1.75f, 0.25f);

        if (moveInput == 0 && !facingRight)
            transform.localScale = new Vector2(-1.75f, 0.25f);
    }

    void StopSlide()
	{
        if (moveInput < 0 || !facingRight)
        {
            scaleGuy.x *= -1;
            transform.localScale = scaleGuy;
        }
        if (moveInput > 0 || facingRight)
            transform.localScale = scaleGuy;

        UtilisableSpeed = moveSpeed;
        slide = false;
        scaleGuy = scaleGuy2;
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    public void jump()
    {
        StopPlatMove();

        rb.velocity = Vector2.up * jumpforce;
        realJump--;
    }

    public void desableanimJump()
    {
        CanJump = false;
        secondJump = true;
        mAnimator.SetBool("IsJumping", false);
    }

    void jump2()
    {
        rb.velocity = Vector2.up * jumpforce;
        realJump--;
        secondJump = false;
    }

    void Shoot()
{
    if (Input.GetKeyDown(KeyCode.Space) && tempsEntreShotUtile <= 0)
    {
        mAnimator.SetBool("shooting", true);
        GameObject bulletGO = (GameObject)Instantiate(bulletprefab, firePoint.position, firePoint.rotation);
        bulletJellio bullet = bulletGO.GetComponent<bulletJellio>();
        bullet.SetDistanceJellio(transform.position, rangeBullet);
        if (!facingRight)
        {
             bullet.SetCoterBullet(-1f);
            }
            tempsEntreShotUtile = tempsEntreShot;
        }
        tempsEntreShotUtile -= Time.deltaTime;

    }

    public void stopShoot()
	{
        if(secondJump == false)
		{
            mAnimator.SetBool("AutreJump", false) ;
        }
        mAnimator.SetBool("shooting", false);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, rangeBullet) ;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("MP"))
        {
            this.transform.parent = other.transform;
            NotMP = false;
        }
    }

    public void StopPlatMove()
	{
        if (!NotMP)
        {
            this.transform.parent = null;
            NotMP = true;
        }
    }

    void Slap()
	{
        if (Input.GetKeyDown("q") && UsableTimerSlap <= 0)
        {
            slaped = Instantiate(slap, slapPoint.position, slapPoint.rotation);
            if (!facingRight)
            {
                slaped.transform.localScale = slaped.transform.localScale * new Vector2(-1, 1);
            }
            UsableTimerSlap = slapTimer;
        }
        UsableTimerSlap -= Time.deltaTime;
    }


}
