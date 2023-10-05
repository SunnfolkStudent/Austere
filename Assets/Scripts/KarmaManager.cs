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

    public Image hellEnding;
    public Image limboEnding;
    public Image heavenEnding;
    
    public int karmaLevel = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        karmaLevel = PlayerPrefs.GetInt("Karma", 0);
        Debug.Log("KarmaLevel: " + karmaLevel);

        if (SceneManager.GetActiveScene().name == "End_Scene")
        {
            EndingCheck();
        }
    }

    public void AddSmallKarma()
    {
        karmaLevel += 1;
        PlayerPrefs.SetInt("Karma", karmaLevel);
        Debug.Log("KarmaLevel: " + karmaLevel);
    }

    public void AddBigKarma()
    {
        karmaLevel += 3;
        PlayerPrefs.SetInt("Karma", karmaLevel);
        Debug.Log("KarmaLevel: " + karmaLevel);
    }

    public void ResetKarma()
    {
        karmaLevel = 0;
        PlayerPrefs.SetInt("Karma", karmaLevel);
        Debug.Log("KarmaLevel: " + karmaLevel);
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("hit player");
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

    private void EndingCheck()
    {
        if (karmaLevel >= 5)
        {
            hellEnding.enabled = true;
        }else if (karmaLevel >= 1)
        {
            limboEnding.enabled = true;
        }
        else
        {
            heavenEnding.enabled = true;
        }
    }
}
