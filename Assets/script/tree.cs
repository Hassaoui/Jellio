using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class tree : MonoBehaviour, IPointerEnterHandler
{
    private Animator anim;

    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        anim.SetBool("coloring", true);
    }

    public void GoDark()
	{
        anim.SetBool("coloring", false);
    }
}
