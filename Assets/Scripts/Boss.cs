using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Dialogue dialogue;

    public AudioClip BossNoise;

    private InputManager _input;
    private AudioSource _as;

    private void Start()
    {
        _input = GetComponent<InputManager>();
        _as = GetComponent<AudioSource>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && _input.interactHeld)
        {
            TriggerDialogue();
            _as.PlayOneShot(BossNoise);
        }
    }
    
    public void TriggerDialogue ()
    {
        FindFirstObjectByType<BossDialogueManager>().StartDialogue(dialogue);
    }
}