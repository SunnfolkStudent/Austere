using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputNPC : MonoBehaviour
{
    public Dialogue dialogue;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            TriggerDialogue();
        }
    }

    public void TriggerDialogue ()
    {
        FindFirstObjectByType<InputDialogueManager>().StartDialogue(dialogue);
    }
}