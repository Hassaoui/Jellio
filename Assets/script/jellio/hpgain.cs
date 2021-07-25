using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpgain : MonoBehaviour
{
    private GameObject play;
    private Life player;

    public float HpGain = 0;

    void Start()
	{
        play = GameObject.Find("idle");
        player = play.GetComponent<Life>();
	}

    void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player"))
        {
            if (player.getCurrentVie() < player.VieMax)
            {
                player.ReceiveHealth(HpGain);
                gameObject.SetActive(false);
            }

        }
    }
}
