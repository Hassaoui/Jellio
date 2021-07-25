using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
	public Transform destination;
	private GameObject player;
	private GameObject cam;
	private GameObject cam2;
	private bool IsThere = false;

	void Start()
	{
		player = GameObject.Find("idle");
		cam = GameObject.Find("CMvcam1");
		cam2 = GameObject.Find("Main Camera");
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		IsThere = true;
	}
	void OnTriggerExit2D(Collider2D other)
	{
		IsThere = false;
	} 

	void Update()
	{
		if (IsThere && Input.GetKeyDown("e"))
		{
			player.transform.position = destination.position;
			cam.SetActive(false);
			cam2.transform.position = destination.position;
			cam.SetActive(true);
		}
	}
}

