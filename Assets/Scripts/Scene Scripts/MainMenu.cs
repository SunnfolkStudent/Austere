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
        //GameObject.FindGameObjectWithTag("Music").GetComponent<MusicController>().StopMusic();
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Intro_Scene");
    }

    public void Settings()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicController>().PlayMusic();
        SceneManager.LoadScene("Controls");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Application Quit");
    }
}
