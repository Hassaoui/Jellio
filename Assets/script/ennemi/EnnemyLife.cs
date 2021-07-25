using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyLife : MonoBehaviour
{
    public int PointOnDeath;
    public string nameBadGuy;
    public bool IsBoss = false;
    public float hP = 2f;
    public GameObject bulletHitPrefab;
    public GameObject slapHitPrefab;
    public Transform bulletPoint;
    public Transform slappoint;
    public healthBar healthbar;
    public GameObject StuffToDesactivate;
    public GameObject other;
    public bool IsCane;
    public GameObject littleOnes;
    public Transform SpawnPoint;

    //private
    private int amountKilled;

    void Start()
	{
        if (healthbar != null)
            healthbar.SetMaxHealth(hP);
    }

    void Update()
    {
        if(hP <= 0)
		{
            if(StuffToDesactivate != null)
			{
                StuffToDesactivate.SetActive(false);
			}
			if (IsBoss)
			{
                other.GetComponent<Animator>().SetBool("oppening", true);
            }
            PointMaker.Points += PointOnDeath;
            amountKilled = PlayerPrefs.GetInt(nameBadGuy + "killed", 0) + 1;
            PlayerPrefs.SetInt(nameBadGuy + "killed", amountKilled);
            PlayerPrefs.SetInt(nameBadGuy + "amoutOfPoints", amountKilled * PointOnDeath);
            Destroy(gameObject);
		}
    }

    public void takeDmg(float dmgdealt, bool IsSlap)
	{
        if (IsSlap)
            Instantiate(slapHitPrefab, slappoint.position, transform.rotation);
        if (!IsSlap)
            Instantiate(bulletHitPrefab, bulletPoint.position, transform.rotation);
        hP -= dmgdealt;
        if (healthbar != null)
            healthbar.SetHealth(hP);
		if (IsCane)
		{
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        int ra = Random.Range(1, 4);
        for (int i = 0; i < ra; i++)
        {
             Instantiate(littleOnes, SpawnPoint.position, transform.rotation);

            yield return new WaitForSeconds(.2f);
        }
        
    }
}
