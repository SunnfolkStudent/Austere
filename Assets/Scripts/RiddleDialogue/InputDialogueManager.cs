using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class InputDialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    private string textInput;
    public GameObject inputField;
    public string answer = "phone";

    public GameObject key;
    public AudioClip keyDrop;

    public static bool playerControlsDisabled = false;

    public Animator animator;
    
    private Queue<string> sentences;
    private InputManager _inputManager;
    private AudioSource _audio;

    public EventSystem _System;
        
    void Start()
    {
        sentences = new Queue<string>();
        _inputManager = GetComponent<InputManager>();
        _audio = GetComponent<AudioSource>();
        key.gameObject.SetActive(false);
        
        if (_System.currentSelectedGameObject != null)
        {
            _System.SetSelectedGameObject(null);
        }
    }

    private void Update()
    {
        if (_inputManager.escPressed)
        {
            EndDialogue();
        }

        if (_inputManager.enterHeld)
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        textInput = null;
        animator.SetBool("IsOpen", true);
        playerControlsDisabled = true;

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            AnswerCheck();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        textInput = null;
        if (_System.currentSelectedGameObject != null)
        {
            _System.SetSelectedGameObject(null);
        }
        
        playerControlsDisabled = false;
    }

    public void AnswerCheck()
    {
        textInput = inputField.GetComponent<TMP_Text>().text;
        
        if (textInput.Contains(answer))
        { 
               EndDialogue();
               key.gameObject.SetActive(true);
               _audio.PlayOneShot(keyDrop);
        }
        
    }

    /*IEnumerator ClearText()
    {
        while (true)
        {
            Debug.Log("Clear text");
            inputField.TMP_Text.text = "A line of text.";
            yield return new WaitForSeconds(1.0f);
            inputField.GetComponent<TMP_Text>().text = string.Empty;
            yield return new WaitForSeconds(1.0f);
        }
    }*/
}