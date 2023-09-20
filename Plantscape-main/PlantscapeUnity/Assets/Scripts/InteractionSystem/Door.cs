using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    private bool isDialogueInProgress = false;
    private Animator doorAnimation;

    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;

    public Dialogue firstDialogue;
    public Dialogue secondDialogue;

    public Key key;
    public Inventory inventory;
    public GameObject puerta;

    void Start()
    {
        doorAnimation = puerta.GetComponent<Animator>();
    }

    public bool Interact(Interactor interactor)
    {
        if (isDialogueInProgress)
        {
            return false;
        }

        if (inventory != null && inventory.HasItem(key.keyItem))
        {
            StartCoroutine(TriggerAndHandleDialogue(secondDialogue));
            inventory.UseItem(key.keyItem);
            puerta.SetActive(false);
            doorAnimation.Play("SlideDoor");
        }
        else
        {
            StartCoroutine(TriggerAndHandleDialogue(firstDialogue));
        }

        return true;
    }

    public void StartClosingAnimation()
    {
        // Play the door closing animation
        StartCoroutine(WaitingcloseDoor());

        // doorAnimation.Play("CloseDoor");
    }
    IEnumerator WaitingcloseDoor()
    {
        yield return new WaitForSeconds(3);
        doorAnimation.Play("CloseDoor");
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
        isDialogueInProgress = false;
    }
}
