using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject surQuitterVersMenu;
    public GameObject surQuitter;
    public GameObject menu;
    public GameObject settings;
    public GameObject Controls;
    public AudioMixer audioMixer;

    //private
    private bool menuIsActive = false;
    
    void Start()
    {
        if(menu != null)
            menu.SetActive(false);
    }

    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
            updateMenuActivity();
		}
    }

    void updateMenuActivity()
	{
        menuIsActive = !menuIsActive;
        if (menuIsActive)
            Pause();
        else
            Resume();
    }

    void Pause()
	{
        menu.SetActive(true);
        Time.timeScale = 0f;
    }

    void Resume()
	{
        menu.SetActive(false);
        surQuitter.SetActive(false);
        surQuitterVersMenu.SetActive(false);
        settings.SetActive(false);
        Controls.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ActivateQuitter()
	{
        surQuitter.SetActive(true);
	}

    public void DésactivateQuitter()
    {
        surQuitter.SetActive(false);
    }

    public void Quitter()
	{
        Application.Quit();
	}
    
    public void ActivateQuitterVersMenu()
	{
        surQuitterVersMenu.SetActive(true);
	}

    public void DésactivateQuitterVersMenu()
    {
        surQuitterVersMenu.SetActive(false);
    }

    public void QuitterVersMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName: "MainMenu");
    }

    public void OuvrirSettings()
	{
        settings.SetActive(true);
        menu.SetActive(false);
	}

    public void FermerSettingsEtOuvrirMenu()
	{
        settings.SetActive(false);
        menu.SetActive(true);
	}

    public void OuvrirControls()
	{
        settings.SetActive(false);
        Controls.SetActive(true);
	}

    public void FermerControls()
	{
        Controls.SetActive(false);
        menu.SetActive(true) ;
	}

    public void SetVolume(float volume)
	{
        audioMixer.SetFloat("volume", volume);
	}
}
