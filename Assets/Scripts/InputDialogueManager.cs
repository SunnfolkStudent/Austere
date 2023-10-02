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
    public Button exitButton;

    private string theAnswer;
    public GameObject inputField;

    public Animator animator;
    
    private Queue<string> sentences;
    private InputManager _inputManager;
    
    void Start()
    {
        sentences = new Queue<string>();
        _inputManager = GetComponent<InputManager>();
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
    }

    void AnswerCheck()
    {
        if (_inputManager.answerPressed)
        { 
            theAnswer = inputField.GetComponent<Text>().text;
            
            if (theAnswer.Contains("hone") == true)
            { 
               EndDialogue();
               //drop key
            }
        }
        
    }
}