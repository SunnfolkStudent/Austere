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
   
   //private Color original;

   public bool attackable;
   public GameObject emptyBox;

   private InputManager _input;
   private AudioSource _as;
   private SpriteRenderer _sr;

   private void Start()
   {
      _input = GetComponent<InputManager>();
      _as = GetComponent<AudioSource>();
      _sr = GetComponent<SpriteRenderer>();
      currentHealth = maxHealth;
      //original = _sr.color;
      if (key==null) return;
      key.gameObject.SetActive(false);
      
   }

   private void Update()
   {
      if (Time.time > canTakeDamageCounter && !canTakeDamage)
      {
         canTakeDamage = true;
      }

      if (emptyBox == null) return;
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
      StartCoroutine(hurtFlash());
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
   
   IEnumerator hurtFlash()
   {
      _sr.color = Color.red;
      yield return new WaitForSeconds(0.1f);
      _sr.color = new Color(1, 1, 1, 1);
   }
}
