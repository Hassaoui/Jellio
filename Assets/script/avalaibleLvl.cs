using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class avalaibleLvl : MonoBehaviour
{
    public Image between;
    public Image lvl;
    public GameObject txt;
    public int lvlnmb;
    public Button but;

    private int activeLvl;

    void Start()
    {
        //PlayerPrefs.SetInt("LvlDone", 0);
        activeLvl = PlayerPrefs.GetInt("LvlDone", 0);
        if (activeLvl < lvlnmb)
		{
            if (between != null)
                between.color = Color.black;
            lvl.color = Color.black;
            txt.SetActive(false);
            but.enabled = false;
        }
    }

    
}
