using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingPoint : MonoBehaviour
{
	public GameObject Door;
	private Vector3 deplus = new Vector3(0, 6f, 0);

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			LastPointAlive.Lastposition = transform.position + deplus;
			if(Door != null)
			{
				Door.SetActive(true);
			}
		}
	}

}
