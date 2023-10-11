using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaContaminada : MonoBehaviour
{
    public Dialogue dialogue;
    public Dialogue secondDialogue;
    
    public Timer timer;
    public GameObject timerUI;
    public AudioClip contaminado;

    public Inventory inventory;
    public PlantaLista planta;
    public GameObject comidagato;
    private bool isDialogueInProgress = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (inventory != null && inventory.HasItem(planta.plantaItem))
            {
                StartCoroutine(TriggerAndHandleDialogue(secondDialogue));
                timer.StopAndResetTimer();
                timerUI.SetActive(false);
                Destroy(gameObject);
                if (comidagato != null) 
                    comidagato.SetActive(true);
            }
            else
            {
                StartCoroutine(TriggerAndHandleDialogue(dialogue));
                timer.StartTimer(); // Start the timer
                timerUI.SetActive(true);
                if (contaminado != null)
                {
                    AudioManager.instance.PlayMusic(contaminado);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Add any necessary actions when the player exits the trigger zone
            timer.StopAndResetTimer(); // Stop and reset the timer
            timerUI.SetActive(false); // Hide the timer UI
            if (!IsAnyOtherReasonToPlayMusic())
            {
                AudioManager.instance.PlayBasemusic();
                //AudioManager.instance.PauseMusic(contaminado);
            }

        }
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

    private bool IsAnyOtherReasonToPlayMusic() {
        return false;
    }
}
