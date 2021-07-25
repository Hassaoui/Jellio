using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelFinish : MonoBehaviour
{
    public Text time;
    public Text Point;
    private GameObject idle;


    void Start()
    {
        time.text = (int)PointMaker.time + " sec";
        Point.text = (int)PointMaker.Points + " Points";
        idle = GameObject.Find("idle");
        idle.SetActive(false);
    }

    
}
