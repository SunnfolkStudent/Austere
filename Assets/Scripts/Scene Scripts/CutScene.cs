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
    public Image blackOut2;
    public Image title;

    private AudioSource _audio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        blackOut.color = new Color(1, 1, 1, 0);
        title.color = new Color(1, 1, 1, 0);
        blackOut2.color = new Color(1, 1, 1, 0);
    }

    public void EndCutScene()
    {
        StartCoroutine(ChangeColorBlack(blackOut, Color.clear, Color.black, 3f));
        StartCoroutine(AudioandChangeScenes());
        StartCoroutine(ChangeColorBlack2(blackOut2, Color.black, Color.clear, 3f));
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
        yield return new WaitForSeconds(3);
        //title.enabled = true;
        //StartCoroutine(ChangeColorTitle(title, Color.black, new Color(1,1,1,1), 3f));
        yield return new WaitForSeconds(8);
        SceneManager.LoadScene("Tutorial_Level");
        yield return null;
    }
    
    IEnumerator ChangeColorBlack2(Image blackout2, Color from, Color to, float duration)
    {
        float timeElapsed = 0.0f;

        float t = 0.0f;

        yield return new WaitForSeconds(6);
        
        title.color = new Color(1, 1, 1, 1);
        
        while (t < 1.0f)
        {
            timeElapsed += Time.deltaTime;
            t = timeElapsed / duration;
            blackOut2.color = Color.Lerp(from, to, t);
            yield return null;
        }
    }
    
   /* IEnumerator ChangeColorTitle(Image title, Color from, Color to, float duration)
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
    }*/
}
