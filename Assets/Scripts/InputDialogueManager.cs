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

    private string theAnswer;
    public GameObject inputField;

    public Animator animator;
    
    private Queue<string> sentences;
    private InputManager _inputManager;
    
    void Start()
    {
        sentences = new Queue<string>();
        _inputManager = GetComponent<InputManager>();
        inputField.SetActive(true);
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
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        AnswerCheck();
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
    }

    public void AnswerCheck()
    {
        theAnswer = inputField.GetComponent<Text>().text;
        
        if (_inputManager.answerPressed && theAnswer.Contains("hone") == true)
        { 
               EndDialogue();
               //drop key
        }
        
    }
}