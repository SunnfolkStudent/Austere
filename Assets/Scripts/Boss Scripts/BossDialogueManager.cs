using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class BossDialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public static bool PlayerControlsDisabled = false;

    public Animator animator;
    
    public List<string> sentences;

    private KarmaManager _karma;
    
    void Start()
    {
        sentences = new List<string>();
        _karma = GetComponent<KarmaManager>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Dialogue Start");
        
        animator.SetBool("IsOpen", true);
        PlayerControlsDisabled = true;

        nameText.text = dialogue.name;

        sentences.Clear();
        
        ChooseNextSentence();

        //DisplayNextSentence();
    }

    private void ChooseNextSentence()
    {
        if (_karma.karmaLevel >= 10)
        {
            HellDialogue();
        }else if (_karma.karmaLevel >= 5)
        {
            LimboDialogue();
        }
        else
        {
            HeavenDialogue();
        }
    }

    private void HellDialogue()
    {
        
    }

    private void LimboDialogue()
    {
        
    }

    private void HeavenDialogue()
    {
        
    }

   /* public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        //string sentence = sentences.Dequeue();
        StopAllCoroutines();
        //StartCoroutine(TypeSentence(sentence));
    }*/

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
        SceneManager.LoadScene("End_Scene");
        //animator.SetBool("IsOpen", false);
        //PlayerControlsDisabled = false;
    }

}