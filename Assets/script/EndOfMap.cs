using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfMap : MonoBehaviour
{
	public bool HasPlatform = false;

	//private 
    private GameObject player;
	private GameObject cam;
	private GameObject cam2;
	private Life dm;
	private Player pla;
	

	void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
		dm = player.GetComponent<Life>();
		cam = GameObject.Find("CMvcam1");
		cam2 = GameObject.Find("Main Camera");
		pla = player.GetComponent<Player>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			player.transform.position = LastPointAlive.Lastposition;
			cam.SetActive(false);
			cam2.transform.position = LastPointAlive.Lastposition;
			cam.SetActive(true);
			dm.TakeDmg(1, "none");
			pla.StopPlatMove();
		}
		if (other.gameObject.CompareTag("Platform"))
		{
			other.gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0f);
			other.gameObject.GetComponent<FallingPlatform>().SetGravity(0);
		}
	}
}
