using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pressAnyDeal : MonoBehaviour
{
    private Animator anim;
    private bool ready = false;

    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    public void FadeIn()
	{
        anim.SetBool("fading", true);
	}

    void StartClick()
	{
        anim.SetBool("startClick", true);
        ready = true;
    }

    void Clicky()
	{
        anim.SetBool("click2", true);
    }

    void Clicky2()
	{
        anim.SetBool("click2", false);
    }

    void Update()
	{
		if (Input.anyKey && ready)
		{
            SceneManager.LoadScene(sceneName: "MainMenu");
        }
	}
}
