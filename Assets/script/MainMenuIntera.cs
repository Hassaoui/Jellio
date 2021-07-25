using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuIntera : MonoBehaviour
{
    private Animator anim;
    public static bool doorOpen = false;
    private bool leverRight = false;
    public MainMenuIntera mn;

    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    void LeverRight()
	{
        anim.SetBool("goigRight", false);
    }

    void LeverLeft()
	{
        anim.SetBool("goigRight", true);
    }

    void OpenDoor()
	{
        anim.SetBool("opening", true);
    }

    void CloseDoor()
	{
        anim.SetBool("opening", false);
    }

    public void Lever()
	{
        leverRight = !leverRight;
        if (leverRight)
        {
            LeverRight();
        }
        else
            LeverLeft();
	}

    public void LeverIsRight()
	{
        mn.OpenDoor();
	}

    public void LeverIsLeft()
	{
        mn.CloseDoor();
	}

    public void Bong()
	{
        anim.SetBool("Bong", true);
    }

    public void StopBong()
	{
        anim.SetBool("Bong", false);
    }
}
