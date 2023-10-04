using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
   public Dialogue dialogue;
   public int maxHealth = 3;
   public int currentHealth;

   private InputManager _input;
   private KarmaManager _karma;

   private void Start()
   {
      _input = GetComponent<InputManager>();
      _karma = GetComponent<KarmaManager>();
      currentHealth = maxHealth;
   }

   private void OnTriggerStay2D(Collider2D other)
   {
      if (other.CompareTag("Player") && _input.interactHeld)
      {
         TriggerDialogue();
      }
   }

   public void TriggerDialogue ()
   {
      FindFirstObjectByType<DialogueManager>().StartDialogue(dialogue);
   }

   public void TakeDamage(int damage)
   {
      currentHealth -= damage;

      if (currentHealth <= 0)
      {
         Destroy(gameObject);
         _karma.karmaLevel -= 3;
      }
   }
}
