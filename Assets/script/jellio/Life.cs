using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public float VieMax = 5;
    public float startingLife = 3;
    public List<HeartScript> ListeDeVie;
    public float vitesseChangeTransparence;
    public float tempsDmg;
    public float checkRadius;
    public LayerMask WhatIsGround;
    public Transform groundCheck;
    public GameObject Deathprefab;



    //private
    private float currentVie;
    private float tempHp;
    private int temp2;
    private bool IsDmg = false;
    private float timer;
    private float timer2;
    private bool transparent = false;
    private GameObject Player;
    private bool kitKatdmg = false;
    private bool IsGrounded;
    private bool _IsGrounded;
    private Player play;
    private Animator mAnimator;
    private KitKat kitKat;
    private GameObject god;
    




    void Start()
    {
        
        mAnimator = this.GetComponent<Animator>();
        Player = GameObject.Find("idle");
        god = GameObject.Find("God");
        play = Player.GetComponent<Player>();
        currentVie = startingLife;
        CheckHp();
        timer = tempsDmg;
        timer2 = vitesseChangeTransparence;
    }

    public float getCurrentVie()
	{
        return currentVie;
	}
    
    void Update()
    {
        IsGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, WhatIsGround);
		
            if (IsDmg)
            {
                timer -= Time.deltaTime;
                timer2 -= Time.deltaTime;
                if (timer2 <= 0 && IsDmg)
                {
                    if (transparent)
                    {
                        this.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1f);
                        transparent = false;
                        timer2 = vitesseChangeTransparence;
                    }
                    else
                    {
                        this.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0f);
                        transparent = true;
                        timer2 = vitesseChangeTransparence;
                    }
                }
                if (timer <= 0)
                {
                    this.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1f);
                    IsDmg = false;
                    timer = tempsDmg;
                    if (kitKatdmg)
                    {
                        Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                        Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                        Player.GetComponent<Player>().enabled = true;
                        Player.GetComponent<Rigidbody2D>().gravityScale = 1;
                        Player.GetComponent<PolygonCollider2D>().isTrigger = false;
                        kitKatdmg = false;
                    }

                }

            }
            if (kitKatdmg && IsGrounded)
            {
                OnGround();
            }
			
        
    }

    public void TakeDmgkitKat(float dmg, bool Doingdmg,string name)
	{
        if(Doingdmg)
		{
            if (!IsDmg)
            {
                minusHealth(dmg, name);
            }
            Player.GetComponent<PolygonCollider2D>().isTrigger = true;
            Player.GetComponent<Rigidbody2D>().gravityScale = 3;
            
            kitKatdmg = true;
        }
	}

    public void TakeDmg(float dmg, string name)
	{
		if (!IsDmg)
        {
            minusHealth(dmg, name);
        }
    }

    void minusHealth(float dmg, string nameEnnemy)
	{
        int timeHit = PlayerPrefs.GetInt(nameEnnemy + "timesHit", 0) + 1;
        PlayerPrefs.SetInt(nameEnnemy + "timesHit", timeHit);
        FindObjectOfType<AudioManager>().Play("LoseHeart");
        currentVie -= dmg;
        if (currentVie <= 0)
        {
            currentVie = 0;
            //FindObjectOfType<AudioManager>().PauseAll();
            FindObjectOfType<AudioManager>().Play("Lose1Hp");
        }
        CheckHp();
        IsDmg = true;
    }

    public void ReceiveHealth(float heal)
	{
        currentVie += heal;
        if(currentVie > VieMax)
		{
            currentVie = VieMax;
		}
        CheckHp();
	}

    private void CheckHp()
	{
        tempHp = currentVie;
		for (int i = 0; i < ListeDeVie.Count; i++)
		{
            if (ListeDeVie[i].index(i + 1) <= currentVie)
            {
                ListeDeVie[i].PleinVie();
            }
            if (ListeDeVie[i].index(i + 1) > currentVie)
			{
                ListeDeVie[i].NoLife();
            } 
            
        }
        if (tempHp % 1 == 0.5)
        {
            tempHp = tempHp - 0.5f;
            temp2 = (int)tempHp;
            ListeDeVie[temp2].demiVie();
        }

		if (currentVie <= 0)
		{
            Instantiate(Deathprefab, transform.position, transform.rotation);
            GodScript.dead = true;
            Player.SetActive(false);

        }
    }

    void OnGround()
    {
        Player.GetComponent<Rigidbody2D>().gravityScale = 0;
        Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        Player.GetComponent<Player>().enabled = false;
    }

    public void SetKitKat(KitKat kit)
	{
        kitKat = kit;
	}

    public void SetLife(int life)
	{
        currentVie = life;
        CheckHp();
	}
}
