using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movingplatform : MonoBehaviour
{

    public Vector3 moveInput;
    public float speed = 3;
    public Transform plusGrand;
    public Transform plusPetit;
    public LineRenderer linerenderer;

    private bool onceOnly = true;
    private float timer = 2;
    private float timer2 = 0;

    void Start()
	{
        placeLine();
	}

    void Update()
    {
        if(timer2 > 0)
		{
            timer2 -= Time.deltaTime;
        }
        if (timer2 <= 0)
            onceOnly = true;
		if (onceOnly)
        {
            if (Vector2.Distance(transform.position, plusGrand.position) <= 0.7f || Vector2.Distance(transform.position, plusPetit.position) <= 0.7f)
            {
                moveInput = -moveInput;
                onceOnly = false;
                timer2 = timer;
            }
        }
        transform.position += moveInput * speed * Time.deltaTime;
    }

    void placeLine()
	{

        linerenderer.SetPosition(0, plusGrand.position);
        linerenderer.SetPosition(1, plusPetit.position);
    }
    
}
