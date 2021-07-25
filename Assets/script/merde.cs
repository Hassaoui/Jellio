using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class merde : MonoBehaviour
{
    public GameObject Aco;

    void Update()
    {
        this.GetComponent<SpriteRenderer>().color = Aco.GetComponent<SpriteRenderer>().color;
        //this.GetComponent<BoxCollider2D>().isTrigger = Aco.GetComponent<PolygonCollider2D>().isTrigger;
    }
}
