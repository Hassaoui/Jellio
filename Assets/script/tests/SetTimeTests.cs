using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTimeTests : MonoBehaviour
{
    public Text text1;
    public Text text2;
    public Text text3;
    public Text text4;


    void Start()
    {
        //PlayerPrefs.SetInt("TempsLvl1", 0);
        text1.text = PlayerPrefs.GetInt("TempsLvl1", 0).ToString();
        text2.text = PlayerPrefs.GetInt("TempsLvl2", 0).ToString();
        text3.text = PlayerPrefs.GetInt("TempsLvl3", 0).ToString();
        text4.text = PlayerPrefs.GetInt("TempsLvl4", 0).ToString();
    }

}
