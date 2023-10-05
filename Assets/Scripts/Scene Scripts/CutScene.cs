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
    public Image title;

    private AudioSource _audio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        blackOut.color = new Color(1, 1, 1, 0);
        title.color = new Color(1, 1, 1, 0);
    }

    public void EndCutScene()
    {
        StartCoroutine(ChangeColorBlack(blackOut, Color.clear, Color.black, 3f));
        StartCoroutine(AudioandChangeScenes());
        //StartCoroutine(ChangeColorTitle(title, Color.clear, new Color(1,1,1,1), 3f));
    }

    IEnumerator ChangeColorBlack(Image blackout, Color from, Color to, float duration)
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
        yield return new WaitForSeconds(5);
        StartCoroutine(ChangeColorTitle(title, Color.clear, new Color(1,1,1,1), 3f));
        yield return new WaitForSeconds(12);
        SceneManager.LoadScene("Tutorial_Level");
        yield return null;
    }
    
    IEnumerator ChangeColorTitle(Image title, Color from, Color to, float duration)
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
}
