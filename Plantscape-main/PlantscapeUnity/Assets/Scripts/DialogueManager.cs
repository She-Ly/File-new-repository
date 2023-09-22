using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;

    public Animator animator;

    public Queue<string> sentences;
    public AudioClip dialogoSonido;

    public bool IsDialogueActive = false;
    public bool lastSentence = false;
    public AudioClip dialogos;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        IsDialogueActive = true;
        if (dialogos != null)
        {
            AudioManager.instance.PlaySoundEffect(dialogos);
        }
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

        if (sentences.Count == 1)
        {
            lastSentence = true;
        }
        if (dialogos != null)
        {
            AudioManager.instance.PlaySoundEffect(dialogos);
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
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
        IsDialogueActive = false;
    }

    void Update()
    {
        if (IsDialogueActive == false)
        {
            lastSentence = false;
        }
    }

}
