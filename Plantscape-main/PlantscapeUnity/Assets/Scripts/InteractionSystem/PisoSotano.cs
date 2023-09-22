using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PisoSotano : MonoBehaviour, IInteractable
{
    private bool isDialogueInProgress = false;
    public GameObject interactionPromptUI; 

    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;

    public Dialogue dialogue;
    public AudioClip sotano;

    private bool isInsideBasement = false; // Variable para rastrear si est�s en el s�tano


    public bool Interact(Interactor interactor)
    {
        if (isDialogueInProgress)
        {
            return false;
        }

        interactionPromptUI.SetActive(false);

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
    public void SetInsideBasement(bool isInside)
    {
        isInsideBasement = isInside;

        // Si est�s dentro del s�tano, reproduce la m�sica en loop
        if (isInsideBasement)
        {
            AudioManager.instance.PlayMusic(sotano);
        }
        // Si no est�s en el s�tano, pausa la m�sica
        else
        {
            AudioManager.instance.PauseMusic();
        }
    }
}
