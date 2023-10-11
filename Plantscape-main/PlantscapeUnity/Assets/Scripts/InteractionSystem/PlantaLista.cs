using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantaLista : MonoBehaviour, IInteractable
{
    private bool isDialogueInProgress = false;

    public GameObject continueButton;
    public GameObject optionsButton;

    public GameObject interactionPromptUI;
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;

    public Dialogue dialogue;
    public Dialogue secondDialogue;
    public DialogueManager dialogueManager;

    public Item plantaItem;
    public Inventory inventory;
    public AudioClip agarrarPlanta;

    public bool Interact(Interactor interactor)
    {
        if (isDialogueInProgress)
        {
            return false;
        }

        interactionPromptUI.SetActive(false);

        // Check if any sentence in the dialogue has different interactions
        bool hasDifferentInteractions = CheckForDifferentInteractions(dialogue);

        // Show/hide buttons based on the result
        continueButton.SetActive(!hasDifferentInteractions);
        optionsButton.SetActive(hasDifferentInteractions);

        TriggerDialogue(dialogue);

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
   
    public void AgarrarPlanta()
    {
        if (inventory != null)
        {
            Item plantaItem = GetComponent<ItemObject>().itemReference;
            inventory.AddItem(plantaItem);
           
            Destroy(gameObject);

            if (agarrarPlanta != null)
            {
                AudioManager.instance.PlaySoundEffect(agarrarPlanta);
            }
        }
        TriggerDialogue(secondDialogue);

    }

    public void EsconderOpciones()
    {
        continueButton.SetActive(true);
        optionsButton.SetActive(false);
    }
}
