using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public bool haveKey;
    public TextMeshPro interactHelp;
    public GameObject helpText;

    private InputManager _input;

    private void Start()
    {
        _input = GetComponent<InputManager>();
        interactHelp.gameObject.SetActive(false);
        haveKey = false;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Key") && _input.interactHeld)
        {
            haveKey = true;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Door") && _input.interactPressed)
        {
            if (haveKey == true)
            {
                DoorUnlock();
            }
            else
            {
                return;
            }
        }
        
        if (other.CompareTag("HelpText"))
        {
            Debug.Log("interactText");
            interactHelp.gameObject.SetActive(true);
             DestroyObjectDelayed();
        }
    }


    private void DestroyObjectDelayed()
    {
        Destroy(interactHelp, 10);
        Destroy(helpText, 10);
    }

    private void DoorUnlock()
    {
        //Animator.SetBool("Open", true);

        //door becomes available to go through
    }
}
