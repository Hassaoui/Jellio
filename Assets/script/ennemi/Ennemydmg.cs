using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemydmg : MonoBehaviour
{
    public bool IsBullet = false;
    public bool IsKitKat = false;
    public float DmgDone;
    public string nameEnnemy;


    //private
    private GameObject play;
    private Life player;
    private bool Doingdmg = false;

    void Start()
    {
        play = GameObject.Find("idle");
        player = play.GetComponent<Life>();
    }
    void OnTriggerEnter2D(Collider2D other)
	{
        if(other.gameObject.CompareTag("Player"))
        {
            if (IsBullet)
            {
                if(nameEnnemy != null)
                    player.TakeDmg(DmgDone, nameEnnemy);
                else
                    player.TakeDmg(DmgDone, "none");
                 Destroy(gameObject);
            }
			if (IsKitKat)
			{
                
                Doingdmg = true;
                player.TakeDmgkitKat(DmgDone, Doingdmg, nameEnnemy);
                player.SetKitKat(this.gameObject.GetComponent<KitKat>());
                play.GetComponent<Player>().enabled = false;
                

            }
			else
			{
                player.TakeDmg(DmgDone, nameEnnemy);
			}

        }
	}

    void OnTriggerExit2D(Collider2D other)
	{
        if (other.gameObject.CompareTag("Player"))
        {
			if (IsKitKat)
			{
                Doingdmg = false;
                //player.TakeDmgkitKat(DmgDone, Doingdmg);
                play.GetComponent<Player>().enabled = true;
            }
        }
    }


}
