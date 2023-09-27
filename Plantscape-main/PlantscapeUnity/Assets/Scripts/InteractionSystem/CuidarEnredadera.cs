using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuidarEnredadera : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    public GameObject interactionPromptUI; 

    public Dialogue firstDialogue;
    public Dialogue secondDialogue;
    public Dialogue thirdDialogue;

    public GameObject continueButton;
    public GameObject optionsButton;

    private bool isDialogueInProgress = false;

    public WaterManager waterManager;

    public GameObject newSlot;
    public GameObject colliderPiso;

    public AudioClip regarPlanta;
    public AudioClip canto;



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

    public void DarAgua()
    {
        StartCoroutine(TriggerAndHandleDialogue(thirdDialogue));
        newSlot.SetActive(true);
        Destroy(gameObject);
        colliderPiso.SetActive(false);
        if (regarPlanta != null)
        {
            AudioManager.instance.PlaySoundEffect(regarPlanta);
        }
    }

    public void Cantar()
    {
        StartCoroutine(TriggerAndHandleDialogue(secondDialogue));
        if (canto != null)
        {
            AudioManager.instance.PlaySoundEffect(canto);
        }
    }

    public void EsconderOpciones()
    {
        continueButton.SetActive(true);
        optionsButton.SetActive(false);
    }
}