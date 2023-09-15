using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantaEnredadera : MonoBehaviour, IInteractable
{
    public GameObject agujeroCollider;

    public GameObject continueButton;
    public GameObject optionsButton;

    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;

    public Dialogue dialogue;
    public DialogueManager dialogueManager;

    private bool isDialogueInProgress = false;
    public GameObject interactionPromptUI;
    public AudioClip bajarEnredadera;

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
        continueButton.SetActive(!hasDifferentInteractions); //3 botones, subir, bajar y nevermind, los tres le dan al siguiente dialogo pero subir y bajar hacen sus respectivas acciones
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

    public void Bajar()
    {
        agujeroCollider.SetActive(false);
        //play animacion de camara y player bajando
        if (bajarEnredadera != null)
        {
            AudioManager.instance.PlaySoundEffect(bajarEnredadera);
        }
    }

    public void Subir()
    {
        agujeroCollider.SetActive(false);
        //play animacion de camara y player subiendo
        if (bajarEnredadera != null)
        {
            AudioManager.instance.PlaySoundEffect(bajarEnredadera);
        }
    }
}
