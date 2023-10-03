using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
   public Dialogue dialogue;

   private InputManager _input;

   private void Start()
   {
      _input = GetComponent<InputManager>();
   }

   private void OnTriggerStay2D(Collider2D other)
   {
      if (other.CompareTag("Player") && _input.interactPressed)
      {
         TriggerDialogue();
      }
   }

   public void TriggerDialogue ()
   {
      FindFirstObjectByType<DialogueManager>().StartDialogue(dialogue);
   }
}
