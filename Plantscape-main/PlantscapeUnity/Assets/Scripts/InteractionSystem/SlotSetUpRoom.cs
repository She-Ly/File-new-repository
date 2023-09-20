using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotSetUpRoom : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;

    public PlantaSetUpRoom planta;

    public GameObject newSlot;

    public Inventory inventory;

    public GameObject continueButton;
    public GameObject optionsButton;

    public Dialogue firstDialogue;
    public Dialogue secondDialogue;
    public Dialogue thirdDialogue;

    private bool isDialogueInProgress = false;
    public GameObject interactionPromptUI; 

    public bool Interact(Interactor interactor)
    {
        if (isDialogueInProgress)
        {
            return false;
        }

        interactionPromptUI.SetActive(false);

        // Check if any sentence in the dialogue has different interactions
        bool hasDifferentInteractions = CheckForDifferentInteractions(firstDialogue);


        // Show/hide buttons based on the result
        continueButton.SetActive(!hasDifferentInteractions);
        optionsButton.SetActive(hasDifferentInteractions);

        StartCoroutine(TriggerAndHandleDialogue(firstDialogue));

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
        interactionPromptUI.SetActive(true);
        isDialogueInProgress = false;
    }

    private bool CheckForDifferentInteractions(Dialogue dialogue)
    {
        // Iterate through the hasDifferentInteractions array and return true if any value is true
        for (int i = 0; i < dialogue.sentences.Length; i++)
        {
            if (dialogue.hasDifferentInteractions[i])
            {
                return true;
            }
        }
        return false;
    }

    public void Plantar()
    {
        if (inventory != null && inventory.HasItem(planta.plantaItem))
        {
            newSlot.SetActive(true);
            Destroy(gameObject);
            StartCoroutine(TriggerAndHandleDialogue(thirdDialogue));
            inventory.UseItem(planta.plantaItem);
        }
         else
        { 
            // Handle the case where the seed item is not in the inventory
            EsconderOpciones();
            StartCoroutine(TriggerAndHandleDialogue(secondDialogue));
        }

    }

    public void EsconderOpciones()
    {
        optionsButton.SetActive(false);
        continueButton.SetActive(true);
    }
}
