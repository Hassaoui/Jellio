using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camearfolow : MonoBehaviour
{
    public Transform idle;


    void Update()
    {
        this.transform.position = idle.position + new Vector3(0, 0, -15);
    }
}
