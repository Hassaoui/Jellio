using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GodScript : MonoBehaviour
{
    public GameObject Go;
    public int VieGen;
    private int vieGenStartLvl = 2;
    public int __timer = 2;
    public Text txt;
    private GameObject cam;
    private GameObject cam2;
    public SnakeTrap ST;

    public static bool dead = false;
    private float _timer;
    private GameObject Player;
    private Player play;
    private Life life;

    [Header("lifes")]
    public List<GameObject> lifes;

   
    // Start is called before the first frame update
    void Start()
    {
        VieGen = vieGenStartLvl;
        txt.text = VieGen.ToString();
        cam = GameObject.Find("CMvcam1");
        cam2 = GameObject.Find("Main Camera");
        _timer = __timer;
        Player = GameObject.Find("idle");
        play = Player.GetComponent<Player>();
        life = Player.GetComponent<Life>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0)
            {
                ReviveStuf();
                _timer = __timer;
            }
        }

    }
    void ReviveStuf()
    {
        VieGen--;
        if (VieGen < 0)
        {
            FindObjectOfType<AudioManager>().PauseAll();
            FindObjectOfType<AudioManager>().Play("CompleteLoss");
            Go.SetActive(true);
            dead = false;
        }
        else
        {
            Player.SetActive(true);
            Player.transform.position = LastPointAlive.LevelStart;
            cam.SetActive(false);
            cam2.transform.position = LastPointAlive.LevelStart;
            cam.SetActive(true);
            play.StopPlatMove();
            life.SetLife(4);
            dead = false;
            LastPointAlive.Lastposition = LastPointAlive.LevelStart;
            if (ST != null)
                ST.activatePlatform();
            restartHeart();
        }
        txt.text = VieGen.ToString();
    }

    void restartHeart()
	{
		for (int i = 0; i < lifes.Count; i++)
		{
			if (!lifes[i].activeSelf)
			{
                lifes[i].SetActive(true);
            }
		}
	}
}
