using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuidarPlantaVida : MonoBehaviour, IInteractable
{
    public GameObject llave;
    public GameObject nota;

    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    public GameObject interactionPromptUI; 

    public Dialogue firstDialogue;
    public Dialogue secondDialogue;
    public Dialogue thirdDialogue;
    public Dialogue fourthDialogue;

    public GameObject continueButton;
    public GameObject optionsButton;

    private bool isDialogueInProgress = false;

    public WaterManager waterManager;
    private bool isWatered = false;

    public AudioClip regarPlanta;
    public AudioClip canto2;


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

    public void Cantar()
    {
        if (isWatered)
        {
            StartCoroutine(TriggerAndHandleDialogue(secondDialogue));
            llave.SetActive(true);
            nota.SetActive(false);
            if (canto2 != null)
            {
                AudioManager.instance.PlaySoundEffect(canto2);
            }
        }

        else
        {
            StartCoroutine(TriggerAndHandleDialogue(thirdDialogue));
        }

    }

    public void RegarPlanta()
    {
        if (isWatered)
        {
            StartCoroutine(TriggerAndHandleDialogue(fourthDialogue));
            if (regarPlanta != null)
            {
                AudioManager.instance.PlaySoundEffect(regarPlanta);
            }
        }
        else
        {
            waterManager.WaterPlant();
            isWatered = true;
        }
    }

    public void EsconderOpciones()
    {
        continueButton.SetActive(true);
        optionsButton.SetActive(false);
    }

}