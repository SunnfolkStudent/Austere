using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
   public Dialogue dialogue;
   public int maxHealth = 3;
   public int currentHealth;

   public AudioClip ghostSigh;
   public AudioClip ghostHurt;

   public GameObject key;
   public bool hasKey;

   private bool canTakeDamage;
   private float canTakeDamageTime = 0.02f;
   private float canTakeDamageCounter;

   public bool attackable;
   public GameObject emptyBox;

   private InputManager _input;
   private AudioSource _as;

   private void Start()
   {
      _input = GetComponent<InputManager>();
      _as = GetComponent<AudioSource>();
      currentHealth = maxHealth;
      key.gameObject.SetActive(false);
   }

   private void Update()
   {
      if (Time.time > canTakeDamageCounter && !canTakeDamage)
      {
         canTakeDamage = true;
      }

      if (emptyBox.gameObject.active)
      {
         attackable = false;
      }
      else
      {
         attackable = true;
      }
   }

   private void OnTriggerStay2D(Collider2D other)
   {
      if (other.CompareTag("Player") && _input.interactHeld)
      {
         TriggerDialogue();
         _as.PlayOneShot(ghostSigh);
      }
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("AttackCircle") && canTakeDamage && attackable)
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
      _as.PlayOneShot(ghostHurt);

      if (currentHealth <= 0)
      {
         if (hasKey == true)
         {
            key.gameObject.SetActive(true);
         }
         Die();
      }
   }
   
   public void Die()
   {
      KarmaManager.instance.AddBigKarma();
      Destroy(gameObject);
   }
}
