using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastPointAlive : MonoBehaviour
{
    public static Vector3 Lastposition;
    public Transform player;
    public static Vector3 LevelStart;

    void Start()
    {
        LevelStart = player.position;
        Lastposition = player.position;
    }
}
