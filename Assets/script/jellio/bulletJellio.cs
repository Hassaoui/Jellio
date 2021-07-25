using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletJellio : MonoBehaviour
{
    public float SpeedBullet = 2f;


    //private
    private Vector2 dir;
    private float coterBullet = 1f;
    private Rigidbody2D rb;
    private Vector2 scalebullet;
    private Vector2 distanceJellio;
    private float distanceBoss = 2f;

    void Start()
	{
        scalebullet = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        dir = new Vector2(coterBullet, 0);
	}

    void Update()
    {

        float distancePerFrame = SpeedBullet * Time.deltaTime;
        transform.Translate(distancePerFrame * dir, Space.World);

        if (Vector2.Distance(transform.position, distanceJellio) >= distanceBoss)
        {
            Destroy(gameObject);
        }
    }


    public void SetCoterBullet(float input)
	{
        coterBullet = input;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler; 
    }

    public void SetDistanceJellio(Vector2 dis, float distance)
	{
        distanceJellio = dis;
        distanceBoss = distance;
	}
}
