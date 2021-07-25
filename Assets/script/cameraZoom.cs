using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraZoom : MonoBehaviour
{
    public bool zooming = false;
    public float timerZoom = 2f;
    public GameObject camChanger;
    public GameObject CameraPlayer; 

    //private
    private bool isfocusing = false;
    private float temp;
    private Camera cam;
    private static bool zoomed = true;

    void Start()
    {
        temp = timerZoom;
        cam = camChanger.gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
		if (isfocusing && !zooming && zoomed)
		{
            temp -= Time.deltaTime;
            cam.fieldOfView = Mathf.Lerp(100f, 40.25f, temp / timerZoom);
            if(cam.fieldOfView == 100f)
			{
                isfocusing = false;
                temp = timerZoom;
                zoomed = false;
                
            }
        }

        if (isfocusing && zooming && !zoomed)
        {
            temp -= Time.deltaTime;
            cam.fieldOfView = Mathf.Lerp(40.25f, 100f, temp / timerZoom);
            if (cam.fieldOfView == 40.25f)
            {
                isfocusing = false;
                temp = timerZoom;
                CameraPlayer.SetActive(true);
                camChanger.SetActive(false);
                zoomed = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player") && !zooming)
		{
            CameraPlayer.SetActive(false);
            camChanger.SetActive(true);
            isfocusing = true;
		}

        if (other.gameObject.CompareTag("Player") && zooming)
        {
            isfocusing = true;
        }
    }
}
