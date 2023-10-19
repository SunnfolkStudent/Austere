using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicController>().PlayMusic();
    }

    public void PlayGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Intro_Scene");
    }

    public void Settings()
    {
        SceneManager.LoadScene("Controls");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Application Quit");
    }
}
