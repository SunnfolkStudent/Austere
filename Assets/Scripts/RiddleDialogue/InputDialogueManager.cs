using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputDialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    private string textInput;
    public GameObject inputField;
    public string answer = "phone";

    public GameObject key;

    public static bool playerControlsDisabled = false;

    public Animator animator;
    
    private Queue<string> sentences;
    private InputManager _inputManager;
        
    void Start()
    {
        sentences = new Queue<string>();
        _inputManager = GetComponent<InputManager>();
        key.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (_inputManager.escPressed)
        {
            EndDialogue();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        inputField.SetActive(true);
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
        inputField.SetActive(false);
        playerControlsDisabled = false;
    }

    public void AnswerCheck()
    {
        textInput = inputField.GetComponent<TMP_Text>().text;
        
        if (textInput.Contains(answer))
        { 
               EndDialogue();
               key.gameObject.SetActive(true);
               //key audio
        }
        
    }
}