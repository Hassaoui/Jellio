using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTrap : MonoBehaviour
{
    public float dmg;
	public float timerUntilTransport = 0.2f;
	public List<GameObject> platform;
	public bool teleport = true;
	public bool restartPlatAfterTime;
	

    //private
    private bool playerDmg = false; 
	private GameObject cam;
	private GameObject cam2;
	private GameObject player;
	private float realTimer;
	private GameObject life;
	

	void Start()
	{
		life = GameObject.Find("idle");
		cam = GameObject.Find("CMvcam1");
		cam2 = GameObject.Find("Main Camera");
		realTimer = timerUntilTransport;
	}

	void Update()
	{
		if (playerDmg && teleport )
		{
			realTimer -= Time.deltaTime;
		}

		if (realTimer <= 0 && life.GetComponent<Life>().getCurrentVie()>0)
		{
			player.transform.position = LastPointAlive.Lastposition;
			cam.SetActive(false);
			cam2.transform.position = LastPointAlive.Lastposition;
			cam.SetActive(true);
			playerDmg = false;
			activatePlatform();
			realTimer = timerUntilTransport;
		}
		if(realTimer <= 0 && life.GetComponent<Life>().getCurrentVie() <= 0)
		{
			playerDmg = false;
			realTimer = timerUntilTransport;
		}
	}

    void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Platform"))
		{
            other.gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0f);
			other.gameObject.GetComponent<FallingPlatform>().SetGravity(0);
			if (restartPlatAfterTime)
			{
				other.gameObject.GetComponent<FallingPlatform>().Rest = true;
			}
		}

		if (other.gameObject.CompareTag("Player"))
		{
			player = other.gameObject;
            other.gameObject.GetComponent<Life>().TakeDmg(dmg, "none");
			playerDmg = true;
        }

		if (other.gameObject.CompareTag("Skittle"))
		{
			Destroy(other.gameObject);
		}
	}

	public void activatePlatform()
	{
		for (int i = 0; i < platform.Count; i++)
		{
			if (platform[i].GetComponent<SpriteRenderer>().color == new Color(1.0f, 1.0f, 1.0f, 0f))
			{
				platform[i].GetComponent<FallingPlatform>().SetPlatformBase();
			}
		}
	}
}
