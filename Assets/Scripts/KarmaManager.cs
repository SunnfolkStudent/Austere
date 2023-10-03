using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarmaManager : MonoBehaviour
{
    public int karmaLevel = 0;

    private void Start()
    {
        karmaLevel = PlayerPrefs.GetInt("Karma");
    }

    private void Update()
    {
        PlayerPrefs.SetInt("Karma", karmaLevel);
    }

    void AddKarma()
    {
        karmaLevel--;
    }
}
