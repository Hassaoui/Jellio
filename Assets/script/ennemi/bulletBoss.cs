using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBoss : MonoBehaviour
{
    public float speedBullet = 8f;

    //private
    private Rigidbody2D rb;
    private Transform target;
    private Vector3 dir;
    private float distanceThisFrame;
    private Transform bossposi;
    private float range;
    private float maxRange;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(bossposi == null)
		{
            Destroy(gameObject);
            return;
		}
        maxRange = Vector2.Distance(transform.position, bossposi.position);
        if (maxRange >= range)
        {
            Destroy(gameObject);
            return;
        }
        transform.position += dir * speedBullet * Time.deltaTime;
    }

    public void SetTarget(GameObject _target, Transform bossposition, float _range)
	{
        dir = _target.transform.position - transform.position;
        dir = dir.normalized;
        range = _range;
        bossposi = bossposition;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("block"))
        {
            Destroy(gameObject);
        }
    }

}