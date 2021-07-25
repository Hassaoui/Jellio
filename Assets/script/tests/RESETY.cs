using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RESETY : MonoBehaviour
{
    public bool reset = false;
    void Start()
    {
		if (reset)
		{

            PlayerPrefs.SetInt("LvlDone", 0);
            PlayerPrefs.SetInt("TempsLvl1", 0);
            PlayerPrefs.SetInt("TempsLvl2", 0);
            PlayerPrefs.SetInt("TempsLvl3", 0);
            PlayerPrefs.SetInt("TempsLvl4", 0);

            PlayerPrefs.SetInt("BestLevel1", 0);
            PlayerPrefs.SetInt("BestLevel2", 0);
            PlayerPrefs.SetInt("BestLevel3", 0);
            PlayerPrefs.SetInt("BestLevel4", 0);

            PlayerPrefs.SetInt("Latest1", 0);
            PlayerPrefs.SetInt("Latest2", 0);
            PlayerPrefs.SetInt("Latest3", 0);
            PlayerPrefs.SetInt("Latest4", 0);
        }
    }
}
