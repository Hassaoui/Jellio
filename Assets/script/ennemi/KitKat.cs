using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitKat : MonoBehaviour
{
    public float tempsAir = 2;
	public float speedUp = 2f;
	public Transform PointDehaut;
	public float TempsEntreAction = 0.5f;


	//private
	private float temps_Air;
	private Animator mAnimator = null;
	private Rigidbody2D rb;
	private bool Goingup = false;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		mAnimator = this.GetComponent<Animator>();
		temps_Air = tempsAir;
	}

    void Update()
    {
        temps_Air -= Time.deltaTime;
        if(temps_Air <= 0)
		{
            StartCoroutine("Down");
		}

		if(Goingup && Vector2.Distance(transform.position, PointDehaut.position) <= 1f)
		{
			rb.velocity = new Vector2(0, 0);
			Goingup = false;
		}

    }

    IEnumerator Down()
	{
		for (int i = 0; i < 3; i++)
		{
			if (i == 0)
			{
				mAnimator.SetBool("isAttacking", true);
			}

			if (i == 1)
			{
				rb.gravityScale = 5;
			}

			if(i == 2)
			{
				rb.gravityScale = 0;
				mAnimator.SetBool("isAttacking", false);
				temps_Air = tempsAir;
				rb.velocity = new Vector2(rb.velocity.x, speedUp);
				Goingup = true;
				
			}

			yield return new WaitForSeconds(TempsEntreAction);
		}
	}

	public bool GoingUp()
	{
		return Goingup;
	}
}
