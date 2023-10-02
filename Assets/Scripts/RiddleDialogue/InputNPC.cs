using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputNPC : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue ()
    {
        FindFirstObjectByType<InputDialogueManager>().StartDialogue(dialogue);
    }
}