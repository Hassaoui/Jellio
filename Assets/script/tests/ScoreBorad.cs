using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBorad : MonoBehaviour
{
    [Header("High")]
    public Text High1;
    public Text High2;
    public Text High3;
    public Text High4;
    
    [Header("Lastest")]
    public Text Last1;
    public Text Last2;
    public Text Last3;
    public Text Last4;

    void Start()
    {
        High1.text = PlayerPrefs.GetInt("BestLevel1", 0).ToString();
        High2.text = PlayerPrefs.GetInt("BestLevel2", 0).ToString();
        High3.text = PlayerPrefs.GetInt("BestLevel3", 0).ToString();
        High4.text = PlayerPrefs.GetInt("BestLevel4", 0).ToString();

        Last1.text = PlayerPrefs.GetInt("Latest1", 0).ToString();
        Last2.text = PlayerPrefs.GetInt("Latest2", 0).ToString();
        Last3.text = PlayerPrefs.GetInt("Latest3", 0).ToString();
        Last4.text = PlayerPrefs.GetInt("Latest4", 0).ToString();
    }

}
