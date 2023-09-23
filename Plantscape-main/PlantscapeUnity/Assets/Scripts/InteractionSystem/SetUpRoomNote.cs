using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpRoomNote : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;

    //public GameObject llave;
    public GameObject nota2D;

    private bool firstInteraction = true;
    public Dialogue dialogue;
    private bool isDialogueInProgress = false;
    public GameObject interactionPromptUI;

    public AudioClip sonidoTriunfal; // Agrega tu m�sica triunfal aqu�
    

    
    public bool Interact(Interactor interactor)
    {
        if (isDialogueInProgress)
        {
            return false;
        }

        interactionPromptUI.SetActive(false);

        nota2D.SetActive(true);
        //llave.SetActive(true);
        //agregar musica triunfal cuando se cierre la nota
        if (sonidoTriunfal != null)
        {
            AudioManager.instance.PlaySoundEffect(sonidoTriunfal);
        }
        // Reproduce el sonido triunfal

        return true;
    }
   

    public void TriggerDialogue()
    {
        if (firstInteraction)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
        firstInteraction = false;
    }

}
