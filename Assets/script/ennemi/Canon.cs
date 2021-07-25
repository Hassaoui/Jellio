using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    public float timer = 2;
    public GameObject bulletPrefeb;
    public Transform FirePoint;

    //private 
    private float realTimer;

    void Start()
    {
        realTimer = timer;
    }

    // Update is called once per frame
    void Update()
    {
        realTimer -= Time.deltaTime;
		if (realTimer <= 0)
		{
            Instantiate(bulletPrefeb, FirePoint.position, FirePoint.rotation);
            realTimer = timer;

        }
    }
}
