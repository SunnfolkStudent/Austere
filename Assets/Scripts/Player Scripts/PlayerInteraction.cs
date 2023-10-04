using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class PlayerInteraction : MonoBehaviour
{
    public bool haveKey;
    //public TextMeshPro interactHelp;
    //public GameObject helpText;
    public int sceneBuildIndex;
    public GameObject uiKey;

    private InputManager _input;

    private void Start()
    {
        _input = GetComponent<InputManager>();
        //interactHelp.gameObject.SetActive(false);
        haveKey = false;
        uiKey.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (haveKey == true)
        {
            uiKey.gameObject.SetActive(true);
        }
        else
        {
            uiKey.gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Key") && _input.interactHeld)
        {
            haveKey = true;
            Destroy(other.gameObject);
        }
        
        /*if (other.CompareTag("HelpText"))
        {
            Debug.Log("interactText");
            interactHelp.gameObject.SetActive(true);
             DestroyObjectDelayed();
        }*/
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Exit" && haveKey == true)
        {
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }


    private void DestroyObjectDelayed()
    {
        //Destroy(interactHelp, 10);
        //Destroy(helpText, 10);
    }
}
