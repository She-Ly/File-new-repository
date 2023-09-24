using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGato : MonoBehaviour
{
    public Dialogue dialogue;
    private bool isDialogueInProgress = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(TriggerAndHandleDialogue(dialogue));
            Destroy(gameObject);
        }
    }
    

    public void TriggerDialogue(Dialogue dialogue)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private IEnumerator TriggerAndHandleDialogue(Dialogue dialogue)
    {
        isDialogueInProgress = true;

        TriggerDialogue(dialogue);
        while (FindObjectOfType<DialogueManager>().IsDialogueActive)
        {
            yield return null;
        }
        isDialogueInProgress = false;
    }
}
