using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChange : MonoBehaviour
{
	public string nameNextScene;
	public int LvlDone;
	public bool intro = false;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			if (PlayerPrefs.GetInt("LvlDone", LvlDone) < LvlDone)
				PlayerPrefs.SetInt("LvlDone", LvlDone);
			if (intro)
				changeScene();
		}
	}

	public void changeScene()
	{
		SceneManager.LoadScene(sceneName: nameNextScene);
	}
}
