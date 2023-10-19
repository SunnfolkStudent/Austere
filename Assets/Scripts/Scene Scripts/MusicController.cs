using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{
    private AudioSource _audio;
    private static GameObject _music;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        _audio = GetComponent<AudioSource>();
        
        if (_music == null)
        {
            _music = gameObject;
        }
        else
        {
            DestroyObject(gameObject);
        }
    }

    /*private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Controls")
        {
            PlayMusic();
        }
    }*/

    public void PlayMusic()
    {
        if (_audio.isPlaying) return;
        _audio.Play();
    }

    public void StopMusic()
    {
        _audio.Stop();
    }
}
