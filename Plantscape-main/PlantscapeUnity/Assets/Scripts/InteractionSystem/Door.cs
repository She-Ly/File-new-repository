using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    private bool isDialogueInProgress = false;

    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;

    public Dialogue firstDialogue;
    public Dialogue secondDialogue;

    public Key key;
    public GameObject puerta;

    public bool Interact(Interactor interactor)
    {
        if (isDialogueInProgress)
        {
            return false;
        }

        // Check if the player has the key
        if (key.hasKey)
        {
            StartCoroutine(TriggerAndHandleDialogue(secondDialogue));
            puerta.SetActive(false);
            key.llaveUI.SetActive(false);
        }
        else
        {
            StartCoroutine(TriggerAndHandleDialogue(firstDialogue));
        }

        return true;
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
