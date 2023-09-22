using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBottle : MonoBehaviour, IInteractable
{
    public WaterManager waterManager;

    private bool firstInteraction = true;
    private bool isDialogueInProgress = false;

    [SerializeField] private string _prompt;
    public Dialogue firstDialogue;
    public Dialogue secondDialogue;
    public GameObject botella;

    public GameObject waterUI;

    public GameObject interactionPromptUI; 
    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        if (isDialogueInProgress)
        {
            return false;
        }

        interactionPromptUI.SetActive(false);

        if (firstInteraction)
        {
            StartCoroutine(TriggerAndHandleDialogue(firstDialogue));
            firstInteraction = false;
            waterUI.SetActive(true);
            waterManager.RefillWater();
        }
        else
        {
            StartCoroutine(TriggerAndHandleDialogue(secondDialogue));
        }

        return true;
    }

    public void TriggerDialogue(Dialogue dialogue)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        Destroy(botella);
    }

    private IEnumerator TriggerAndHandleDialogue(Dialogue dialogue)
    {
        isDialogueInProgress = true;

        TriggerDialogue(dialogue);
        while (FindObjectOfType<DialogueManager>().IsDialogueActive)
        {
            yield return null;
        }
        interactionPromptUI.SetActive(true);
        isDialogueInProgress = false;
    }

}