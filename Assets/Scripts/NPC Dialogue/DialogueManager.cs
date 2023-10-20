using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public static bool PlayerControlsDisabled = false;

    public Animator animator;
    
    private Queue<string> sentences;

    public GameObject emptyBox;
    
    public EventSystem _System;
    
    void Start()
    {
        sentences = new Queue<string>();
        emptyBox.gameObject.SetActive(false);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        emptyBox.gameObject.SetActive(true);
        animator.SetBool("IsOpen", true);
        PlayerControlsDisabled = true;

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
            EndDialogue();
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

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        PlayerControlsDisabled = false;
        emptyBox.gameObject.SetActive(false);
        if (_System.currentSelectedGameObject != null)
        {
            _System.SetSelectedGameObject(null);
        }
    }

}
