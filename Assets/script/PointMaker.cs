using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointMaker : MonoBehaviour
{
    public static float time;
    public Text timer;
    public float _timer;
    public static int Points;

    //private 
    public static float __timer;
    

    void Start()
	{
        Points = 0;
        time = 0;
        timer.text = _timer.ToString();
	}

    void Update()
    {
        timeStuff();
    }

    void timeStuff()
	{
        time += Time.deltaTime;
        _timer -= Time.deltaTime;
        __timer = (int)_timer;
        if(__timer <= 10)
		{
            timer.color = Color.red;
		}
        timer.text = __timer.ToString();
    }
}
