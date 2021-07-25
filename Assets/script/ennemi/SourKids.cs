using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourKids : MonoBehaviour
{


    public float SpeedEnnemie = 3f;
    public float CoterDeBase = 1f;
    public Transform turnLeftPoint;
    public Transform TurnRightPoint;
    public float pointDeTurn = 0.5f;
    public List<GameObject> SkittlePrefab;
    public float timeBSkittles = 0.5f;

    //private
    private float moveInput;
    private Rigidbody2D rb;
    private float realTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveInput = CoterDeBase;
        realTimer = timeBSkittles;
    }

    // Update is called once per frame
    void Update()
    {
        realTimer -= Time.deltaTime;

        if(realTimer <= 0)
		{
            int skittle = Random.Range(0, 5);
            Instantiate(SkittlePrefab[skittle], transform.position, transform.rotation);
            realTimer = timeBSkittles;
        }

        if (Vector2.Distance(transform.position, turnLeftPoint.position) <= pointDeTurn)
        {
            moveInput = -1f;
        }

        if (Vector2.Distance(transform.position, TurnRightPoint.position) <= pointDeTurn)
        {
            moveInput = 1f;
        }

        rb.velocity = new Vector2(SpeedEnnemie * moveInput, rb.velocity.y);
    }
}
