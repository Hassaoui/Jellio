using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound1 : MonoBehaviour
{
    public string Sound2Play;
    public bool pauseAll = false;

    void Start()
    {
        if(pauseAll)
            FindObjectOfType<AudioManager>().PauseAll();
        FindObjectOfType<AudioManager>().Play(Sound2Play);
    }
}
