using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputNPC : MonoBehaviour
{
    public Dialogue dialogue;

    private InputManager _input;

    private void Start()
    {
        _input = GetComponent<InputManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && _input.interactHeld)
        {
            TriggerDialogue();
        }
    }

    public void TriggerDialogue ()
    {
        FindFirstObjectByType<InputDialogueManager>().StartDialogue(dialogue);
    }
}