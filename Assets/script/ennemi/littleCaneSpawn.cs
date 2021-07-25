using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class littleCaneSpawn : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpforce = 60f;
    private GameObject CandyGuy;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * jumpforce;
        CandyGuy = GameObject.Find("candyCane01");
    }

    void Update()
	{
        if(CandyGuy == null)
		{
            Destroy(gameObject);
		}
	}

}
