using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;

    public GameObject objetoLlave;
    public GameObject llaveUI;

    public bool hasKey = false;

    public Dialogue dialogue;

    public AudioClip llave;
    public bool Interact(Interactor interactor)
    {
        hasKey = true;
        objetoLlave.SetActive(false);
        llaveUI.SetActive(true);
        TriggerDialogue();
        if (llave != null)
        {
            AudioManager.instance.PlaySoundEffect(llave);
        }
        return true;
    }

      public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
