using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputNPC : MonoBehaviour
{
    public InputDialogue dialogue;

    public void TriggerDialogue ()
    {
        //FindFirstObjectByType<InputDialogueManager>().StartDialogue(dialogue);
    }
}