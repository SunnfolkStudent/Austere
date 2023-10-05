using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutScene : MonoBehaviour
{
    public AudioClip ambulance;
    public Image blackOut;
    public float fadeSpeed = 1f;

    private AudioSource _audio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        blackOut.color = new Color(1, 1, 1, 0);
    }

    public void EndCutScene()
    {
        StartCoroutine(ChangeColor());
        _audio.PlayOneShot(ambulance);
    }

    IEnumerator ChangeColor()
    {
        float alpha = 1.0f;

        while (alpha > 0.0f)
        {
            alpha -= fadeSpeed * Time.deltaTime;
            blackOut.color = new Color(1, 1, 1, 1);
            yield return null;
        }
    }
}
