using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartLevel : MonoBehaviour
{
	public GameObject GO;

	public void RestartLevel()
	{
		GO.SetActive(false);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
