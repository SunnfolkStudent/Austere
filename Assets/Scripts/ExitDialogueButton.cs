using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDialogueButton : MonoBehaviour
{

    public void EndDialogue()
    {
        FindFirstObjectByType<InputDialogueManager>().EndDialogue();
    }
}