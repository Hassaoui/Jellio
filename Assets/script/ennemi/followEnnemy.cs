using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followEnnemy : MonoBehaviour
{
    public Transform followTarger;

    public Vector3 vec;

    // Update is called once per frame
    void Update()
    {
        if(followTarger == null)
		{
            Destroy(gameObject);
		}else
            transform.position = followTarger.position + vec;
    }
}
