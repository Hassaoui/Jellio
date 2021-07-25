using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class midWaySave : MonoBehaviour
{
    private Vector3 deplus = new Vector3(0, 6f, 0);

	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			LastPointAlive.LevelStart = transform.position + deplus;
		}
	}
}
