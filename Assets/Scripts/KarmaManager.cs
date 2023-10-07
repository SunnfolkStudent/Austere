using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KarmaManager : MonoBehaviour
{
    public static KarmaManager instance;

    public GameObject heavenBoss;
    public GameObject limboBoss;
    public GameObject hellBoss;

    public GameObject hellEnding;
    public GameObject limboEnding;
    public GameObject heavenEnding;

    public AudioClip hellSound;
    public AudioClip limboSound;
    public AudioClip heavenSound;

    private AudioSource _audio;
    
    public int karmaLevel = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        karmaLevel = PlayerPrefs.GetInt("Karma", 0);

        if (SceneManager.GetActiveScene().name == "End_Scene")
        {
            EndingCheck();
        }
    }

    public void AddSmallKarma()
    {
        karmaLevel += 1;
        PlayerPrefs.SetInt("Karma", karmaLevel);
    }

    public void AddBigKarma()
    {
        karmaLevel += 3;
        PlayerPrefs.SetInt("Karma", karmaLevel);
    }

    public void ResetKarma()
    {
        karmaLevel = 0;
        PlayerPrefs.SetInt("Karma", karmaLevel);
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (SceneManager.GetActiveScene().name == "BossRoom")
        {
            if (other.CompareTag("Player"))
            {
                if (karmaLevel >= 5)
                {
                    hellBoss.gameObject.SetActive(true);
                }else if (karmaLevel >= 1)
                {
                    limboBoss.gameObject.SetActive(true);
                }
                else
                {
                    heavenBoss.gameObject.SetActive(true);
                }
            }
        }
    }

    private void EndingCheck()
    {
        if (karmaLevel >= 5)
        {
            hellEnding.gameObject.SetActive(true);
            _audio.PlayOneShot(hellSound);
        }else if (karmaLevel >= 1)
        {
            limboEnding.gameObject.SetActive(true);
            _audio.PlayOneShot(limboSound);
        }
        else
        {
            heavenEnding.gameObject.SetActive(true);
            _audio.PlayOneShot(heavenSound);
        }
    }
}
