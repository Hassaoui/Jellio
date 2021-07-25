using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skittles : MonoBehaviour
{
	public float dmg = 0.5f;

	private int timeHit;

	public string nameEnnemy;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			other.GetComponent<Life>().TakeDmg(dmg, nameEnnemy);
			Destroy(gameObject);
		}

		if (other.gameObject.CompareTag("bas"))
		{
			Destroy(gameObject);
		}
	}
}
