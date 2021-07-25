using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gummyguys : MonoBehaviour
{
    
    public float speed = 1f;
    public float moveInput = -1f;
    public LayerMask WhatIsGround;
    public Transform groundCheck;

    //private
    private Rigidbody2D rb;
    private float distanceBoss = 10f;
    private Transform positionBosse;
    private bool gTouch;
    private float checkRadius = 0.01f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        gTouch = Physics2D.OverlapCircle(groundCheck.position, checkRadius, WhatIsGround);

        rb.velocity = new Vector2(speed * moveInput, rb.velocity.y);
        if(positionBosse == null)
		{
            Destroy(gameObject);
            return;
		}
        if(Vector2.Distance(transform.position, positionBosse.position) >= distanceBoss)
		{
            Destroy(gameObject);
		}
		if (gTouch)
		{
            rb.gravityScale = 0;
            rb.velocity = new Vector2(speed * moveInput, 0);
        }
    }

    public void SetVariable(float dB, Transform pos)
	{
        positionBosse = pos;
        distanceBoss = dB;
	}
    
}
