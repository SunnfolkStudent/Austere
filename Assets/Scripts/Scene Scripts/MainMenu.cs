using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Intro_Scene");
    }

    public void Settings()
    {
        SceneManager.LoadScene("Controlles");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Application Quit");
    }
}
