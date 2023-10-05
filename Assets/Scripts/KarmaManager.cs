using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarmaManager : MonoBehaviour
{
    public static KarmaManager instance;
    
    public int karmaLevel = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        karmaLevel = PlayerPrefs.GetInt("Karma", 0);
        Debug.Log("KarmaLevel: " + karmaLevel);
    }

    public void AddSmallKarma()
    {
        karmaLevel += 1;
        PlayerPrefs.SetInt("Karma", karmaLevel);
        Debug.Log("KarmaLevel: " + karmaLevel);
    }

    public void AddBigKarma()
    {
        karmaLevel = +3;
        PlayerPrefs.SetInt("Karma", karmaLevel);
        Debug.Log("KarmaLevel: " + karmaLevel);
    }
}
