using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagGuy : MonoBehaviour
{
    public string nameBadGuy;
    public Text killedAmout;
    public Text amoutOfPoints;
    public Text timesHit;
    public Button but;
    public GameObject buttonImage;
    public bool canBekilled = true;
    public GameObject ifCantBeKilled;

    //private
    int timeHit;
    int AmoutPoint;
    int killed;

    void Start()
    {
        if(PlayerPrefs.GetInt(nameBadGuy + "timesHit", 0) <= 0 && !canBekilled)
		{
            disable();
		}else if(canBekilled)
		{
            if(PlayerPrefs.GetInt(nameBadGuy + "killed", 0) <= 0 && PlayerPrefs.GetInt(nameBadGuy + "timesHit", 0) <= 0)
                    disable();
        }
        timeHit = PlayerPrefs.GetInt(nameBadGuy + "timesHit", 0);
        AmoutPoint = PlayerPrefs.GetInt(nameBadGuy + "amoutOfPoints", 0);
        killed = PlayerPrefs.GetInt(nameBadGuy + "killed", 0);

       


    }

    public void SetStats()
	{
        killedAmout.text = killed.ToString();
        amoutOfPoints.text = AmoutPoint.ToString();
        timesHit.text = timeHit.ToString();
        if (!canBekilled)
            ifCantBeKilled.SetActive(true);
        else
            ifCantBeKilled.SetActive(false);
       
    }

    void disable()
	{
        but.interactable = false;
        this.GetComponent<Image>().color = new Color(0, 0, 0, 1f);
        buttonImage.GetComponent<Image>().color = new Color(1, 1, 1, 0f);
    }
}
