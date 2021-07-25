using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class putTimeIn : MonoBehaviour
{
    public string Tname;
    public string Lvl;
    public GodScript GS;
    public GameObject fini;

    //private
    private int pointPlus = 0;


    void OnTriggerEnter2D(Collider2D other)
    {
         if (other.gameObject.CompareTag("Player"))
         {
            FindObjectOfType<AudioManager>().PauseAll();
            FindObjectOfType<AudioManager>().Play("Win");
            UpdatePoints();
            changeBestTime();
            ChangePoint();
            SetLatest();
            SetFinishScreen();
         }
    }

    void changeBestTime()
	{
       if (PlayerPrefs.GetInt(Tname, 0) > (int)PointMaker.time || PlayerPrefs.GetInt(Tname, 0) == 0)
           PlayerPrefs.SetInt(Tname, (int)PointMaker.time);
    }

    void ChangePoint()
	{
        if (PointMaker.Points > PlayerPrefs.GetInt("BestLevel" + Lvl, 0))
            PlayerPrefs.SetInt("BestLevel" + Lvl, PointMaker.Points);
    }
    void SetLatest()
	{
        PlayerPrefs.SetInt("Latest" + Lvl, PointMaker.Points);
    }

    void UpdatePoints()
	{
        pointPlus += (int)PointMaker.__timer;
        pointPlus += GS.VieGen * 40;
        PointMaker.Points += pointPlus;
    }

    void SetFinishScreen()
	{
        fini.SetActive(true);
	}
}
