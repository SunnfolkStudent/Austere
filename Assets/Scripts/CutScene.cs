using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutScene : MonoBehaviour
{
    public AudioClip ambulance;
    public Image blackOut;

    private AudioSource _audio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        blackOut.color = new Color(1, 1, 1, 0);
    }

    public void EndCutScene()
    {
        StartCoroutine(ChangeColor(true));
        _audio.PlayOneShot(ambulance);
    }

    IEnumerator ChangeColor(bool fadeAway)
    {
        if (fadeAway)
        {
            for (float i = 0; i <= 2050; i -= Time.deltaTime)
            {
                blackOut.color = new Color(1, 1, 1, 1);
                yield return null;
            }
        }
    }
}
