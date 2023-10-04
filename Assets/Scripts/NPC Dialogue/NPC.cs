using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
   public Dialogue dialogue;
   public int maxHealth = 3;
   public int currentHealth;

   private bool canTakeDamage;
   private float canTakeDamageTime = 0.02f;
   private float canTakeDamageCounter;

   private InputManager _input;
   private KarmaManager _karma;

   private void Start()
   {
      _input = GetComponent<InputManager>();
      _karma = GetComponent<KarmaManager>();
      currentHealth = maxHealth;
   }

   private void Update()
   {
      if (Time.time > canTakeDamageCounter && !canTakeDamage)
      {
         canTakeDamage = true;
      }
   }

   private void OnTriggerStay2D(Collider2D other)
   {
      if (other.CompareTag("Player") && _input.interactHeld)
      {
         TriggerDialogue();
      }
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("AttackCircle") && canTakeDamage)
      {
         TakeDamage();
         canTakeDamage = false;
         canTakeDamageCounter = Time.time + canTakeDamageTime;
      }
   }

   public void TriggerDialogue ()
   {
      FindFirstObjectByType<DialogueManager>().StartDialogue(dialogue);
   }

   public void TakeDamage()
   {
      currentHealth -= 1;

      if (currentHealth <= 0)
      {
         Destroy(gameObject);
         _karma.karmaLevel -= 3;
      }
   }
}
