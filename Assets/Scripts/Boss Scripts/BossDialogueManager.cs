using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossDialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public static bool PlayerControlsDisabled = false;

    public Animator animator;
    
    public List<string> sentences;
    
    void Start()
    {
        sentences = new List<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Dialogue Start");
        
        animator.SetBool("IsOpen", true);
        PlayerControlsDisabled = true;

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            //sentences.Enqueue(sentence);
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

        //string sentence = sentences.Dequeue();
        StopAllCoroutines();
        //StartCoroutine(TypeSentence(sentence));
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
    }

}