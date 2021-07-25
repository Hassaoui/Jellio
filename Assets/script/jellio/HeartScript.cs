using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartScript : MonoBehaviour
{
	private Animator m;

	private int lindex = 0;

	void Awake()
	{
		m = gameObject.GetComponent<Animator>();
	}

    public void demiVie()
	{
		m.SetBool("halfLive", true);
		m.SetBool("noLife", false);
		m.SetBool("fullLife", false);

	}

	public void PleinVie()
	{
		m.SetBool("fullLife", true);
		m.SetBool("halfLive", false);
		m.SetBool("noLife", false);
	}

	public void NoLife()
	{
		m.SetBool("noLife", true);
		m.SetBool("halfLive", false);
		m.SetBool("fullLife", false);
	}

	public int index(int ind)
	{
		lindex = ind;
		return lindex;
	}
}
