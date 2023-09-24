using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basura : MonoBehaviour, IInteractable
{private bool firstInteraction = true;
    private bool isDialogueInProgress = false;

    [SerializeField] private string _prompt;
    public Dialogue firstDialogue;
    public Dialogue secondDialogue;

    public GameObject semilla;
    public Item seedItem;
    public Inventory inventory;

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
            if (inventory != null)
            {
                Item seedItem = GetComponent<ItemObject>().itemReference;
                inventory.AddItem(seedItem);
                StartCoroutine(TriggerAndHandleDialogue(firstDialogue));
                firstInteraction = false;
            }
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
        Destroy(semilla);
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
