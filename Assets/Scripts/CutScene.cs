using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        StartCoroutine(ChangeColor(blackOut, Color.clear, Color.black, 3f));
        StartCoroutine(AudioandChangeScenes());
    }

    IEnumerator ChangeColor(Image blackout, Color from, Color to, float duration)
    {
        float timeElapsed = 0.0f;

        float t = 0.0f;
        while (t < 1.0f)
        {
            timeElapsed += Time.deltaTime;
            t = timeElapsed / duration;
            blackOut.color = Color.Lerp(from, to, t);
            yield return null;
        }
    }

    IEnumerator AudioandChangeScenes()
    {
        _audio.PlayOneShot(ambulance);
        yield return new WaitForSeconds(7);
        SceneManager.LoadScene("Tutorial_Level");
        yield return null;
    }
}
