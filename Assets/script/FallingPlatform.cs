using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float timer = 0.5f;
    public float _timer = 2;
    [HideInInspector]
    public bool Rest = false;
    public bool poly = true;
    //private
    private bool StartTimerFalling = false;
    private float timerRestart;
    private Vector3 position;
    private float __timer;

    void Start()
	{
        __timer = _timer;
        timerRestart = timer;
        position = transform.position;
	}

    void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
            StartTimerFalling = true;
		}
        if (other.gameObject.CompareTag("Platform"))
		{
            this.GetComponent<BoxCollider2D>().isTrigger = true;
		}

    }

    void OnTriggerExit2D(Collider2D other)
	{
        if (other.gameObject.CompareTag("Platform"))
        {
            this.GetComponent<BoxCollider2D>().isTrigger = false ;
        }
    }

    void Update()
    {
		if (StartTimerFalling)
		{
            timer -= Time.deltaTime;
            if(timer <= 0)
			{
                this.GetComponent<Rigidbody2D>().gravityScale = 3;
                if(poly)
                    this.GetComponent<BoxCollider2D>().isTrigger = true;
                else 
                    this.GetComponent<PolygonCollider2D>().isTrigger = true;
            }
        }
		if (Rest) 
        {
            __timer -= Time.deltaTime;
			if (__timer <= 0)
			{
                SetPlatformBase();
                Rest = false;
                __timer = _timer;
            }
		}
    }

    public void SetPlatformBase()
	{
        this.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1f);
        this.GetComponent<Rigidbody2D>().gravityScale = 0;
        this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        if (poly)
            this.GetComponent<BoxCollider2D>().isTrigger = false;
        else
            this.GetComponent<PolygonCollider2D>().isTrigger = false;
        transform.position = position;
        StartTimerFalling = false;
    }

    public void SetGravity(float gravity)
	{
        this.GetComponent<Rigidbody2D>().gravityScale = gravity;
    }
}
