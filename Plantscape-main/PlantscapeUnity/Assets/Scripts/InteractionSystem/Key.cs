using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;

    public GameObject objetoLlave;
    public Item keyItem;
    public Inventory inventory;

    public Dialogue dialogue;

    public bool Interact(Interactor interactor)
    {
        Destroy(gameObject);
        Item keyItem = GetComponent<ItemObject>().itemReference;
        inventory.AddItem(keyItem);
        TriggerDialogue();
        return true;
    }

      public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
