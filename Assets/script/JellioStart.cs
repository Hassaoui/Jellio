using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellioStart : MonoBehaviour
{
    public pressAnyDeal ps;

	void Start()
	{
		FindObjectOfType<AudioManager>().Play("MainMenu");
	}

    void StartPress()
	{
		ps.FadeIn();
	}
}
