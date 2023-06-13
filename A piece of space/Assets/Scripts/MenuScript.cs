using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject pauseMenuUi;
    public GameObject looseMenu;
    public GameObject settingMenu;
    public static bool OnPause = false;
    private AudioSource audioSource;
    public AudioClip select;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Select()
    {
        if (PlayerPrefs.GetInt("sounds") == 1) {audioSource.PlayOneShot(select);}
    }

    public void Pause()
    {
        if (PlayerPrefs.GetInt("sounds") == 1) {audioSource.PlayOneShot(select);}
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        OnPause = !OnPause;
    }

    public void Continue()
    {
        if (PlayerPrefs.GetInt("sounds") == 1) {audioSource.PlayOneShot(select);}
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        OnPause = !OnPause;
    }

    public void Quit()
    {
        if (PlayerPrefs.GetInt("sounds") == 1) {audioSource.PlayOneShot(select);}
        Time.timeScale = 1f;
        SceneManager.LoadScene("_MainMenu");
        OnPause = !OnPause;
    }
    
    public void DeathQuit()
    {
        if (PlayerPrefs.GetInt("sounds") == 1) {audioSource.PlayOneShot(select);}
        Time.timeScale = 1f;
        SceneManager.LoadScene("_MainMenu");
    }

    public void Restart()
    {
        if (PlayerPrefs.GetInt("sounds") == 1) {audioSource.PlayOneShot(select);}
        Main.s_health = 10;
        ScoreCounter.score = 0;
        looseMenu.SetActive(false);
        SceneManager.LoadScene("Game");
    }

    public void MenuRestart()
    {
        if (PlayerPrefs.GetInt("sounds") == 1) {audioSource.PlayOneShot(select);}
        Main.s_health = 10;
        ScoreCounter.score = 0;
        SceneManager.LoadScene("Game");
    }

    public void SettingsMenuOpen()
    {
        if (PlayerPrefs.GetInt("sounds") == 1) {audioSource.PlayOneShot(select);}
        settingMenu.SetActive(true);
    }
    public void SettingsMenuClose()
    {
        if (PlayerPrefs.GetInt("sounds") == 1) {audioSource.PlayOneShot(select);}
        settingMenu.SetActive(false);
    }
}

