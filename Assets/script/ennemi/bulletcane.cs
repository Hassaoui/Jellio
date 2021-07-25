using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletcane : MonoBehaviour
{
    public float speedBullet = 2;
    public bool VaDroite = true;
    public float dmg = 0.5f;
    public bool Enhaut = false;
    public bool EnBas = false;

    //private
    private Vector3 dir = new Vector3(1, 0, 0);

    void Update()
    {
		if (Enhaut)
		{
            dir = new Vector3(0, 1, 0);
            transform.position += dir * speedBullet * Time.deltaTime;
            return;
        }
		if (EnBas)
		{
            dir = new Vector3(0, -1, 0);
            transform.position += dir * speedBullet * Time.deltaTime;
            return;
        }
        if (!VaDroite)
            dir = new Vector3(-1, 0, 0); 
        else
            dir = new Vector3(1, 0, 0);

        transform.position += dir * speedBullet * Time.deltaTime;
    }
    void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
            other.gameObject.GetComponent<Life>().TakeDmg(dmg, "none");
            Destroy(gameObject);
		}
		if (other.gameObject.CompareTag("Ground"))
		{
            Destroy(gameObject);
		}
	}
}
