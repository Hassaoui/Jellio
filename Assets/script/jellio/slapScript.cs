using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slapScript : MonoBehaviour
{
    public GameObject Slap;
	public float dmg = 1f;
	public bool IsSlap = true;

	//private



    public void StartBoxCollider()
	{
		Slap.GetComponent<BoxCollider2D>().enabled = true;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Ennemy")
		{
			if(IsSlap)
				other.GetComponent<EnnemyLife>().takeDmg(dmg, IsSlap);
			else
			{
				other.GetComponent<EnnemyLife>().takeDmg(dmg, IsSlap);
				Destroy(gameObject);
			}
		}
	}
}
