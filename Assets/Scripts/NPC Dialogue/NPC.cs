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

   private void OnCollisionEnter2D(Collision2D collision)
   {
      if (collision.gameObject.tag == "Player" && _input.interactPressed)
      {
         TriggerDialogue();
      }
   }

   public void TriggerDialogue ()
   {
      FindFirstObjectByType<DialogueManager>().StartDialogue(dialogue);
   }
}
