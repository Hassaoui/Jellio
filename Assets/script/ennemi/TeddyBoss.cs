using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeddyBoss : MonoBehaviour
{
    [Header("bullet Part")]
    public float tempsEntreBullet = 0.5f;
    public float tempsEntreBurst = 3f;
    public int bulletParBurst = 3;
    public float distanceAvantAttaque = 10f;
    public Transform firePoint;
    public GameObject bulletPrefabJaune;
    public GameObject bulletPrefabRouge;
    public GameObject bulletPrefabRose;
    public GameObject bulletPrefabVert;
    public bool disableBullet = false;

    [Header("Teddy Part")]
    public GameObject teddyPurple;
    public GameObject teddyRouge;
    public GameObject teddyGreen;
    public float tempsEntreGummy = 5f;
    public Transform firePoint2;



    // private
    private float tempsEntreBurstUtile;
    private float distanceJellio = 1000;
    private GameObject bulletPrefab;
    private float _tempsEntreGummy;
    private GameObject teddy;
    private GameObject target;

    void Start()
    {
        tempsEntreBurstUtile = tempsEntreBurst;
        _tempsEntreGummy = tempsEntreGummy;
        target = GameObject.Find("idle");
    }

    // Update is called once per frame
    void Update()
    {
       distanceJellio = Vector2.Distance(transform.position, target.transform.position);

        if (tempsEntreBurstUtile <= 0 && distanceJellio <= distanceAvantAttaque)
		{
            StartCoroutine(Shoot());
            tempsEntreBurstUtile = tempsEntreBurst;
        }
        tempsEntreBurstUtile -= Time.deltaTime;

        if(_tempsEntreGummy <= 0 && distanceJellio <= distanceAvantAttaque)
		{
            ShootTeddys();
            _tempsEntreGummy = tempsEntreGummy;
		}
        _tempsEntreGummy -= Time.deltaTime;
    }

    IEnumerator Shoot()
	{
		if (!disableBullet) {
            for (int i = 0; i < bulletParBurst; i++)
            {
                if (i == 0)
                    bulletPrefab = bulletPrefabJaune;
                if (i == 1)
                    bulletPrefab = bulletPrefabRose;
                if (i == 2)
                    bulletPrefab = bulletPrefabRouge;
                if (i == 3)
                    bulletPrefab = bulletPrefabVert;
                GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                bulletBoss bullet = bulletGO.GetComponent<bulletBoss>();
                bullet.SetTarget(target, this.transform, distanceAvantAttaque);
                yield return new WaitForSeconds(tempsEntreBullet);
            }
            tempsEntreBurstUtile = tempsEntreBurst;
        }
    }

    void ShootTeddys()
	{
        int ra = Random.Range(1,4);
        if (ra == 1)
            teddy = teddyGreen;
        if (ra == 2)
            teddy = teddyPurple;
        if (ra == 3)
            teddy = teddyRouge;


        GameObject teedyGO = (GameObject)Instantiate(teddy, firePoint2.position, firePoint2.rotation);
        gummyguys gummy = teedyGO.GetComponent<gummyguys>();
        gummy.SetVariable(distanceAvantAttaque, this.transform);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, distanceAvantAttaque);
    }
}
