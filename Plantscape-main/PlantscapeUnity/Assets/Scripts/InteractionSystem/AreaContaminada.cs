using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaContaminada : MonoBehaviour
{
    public Dialogue dialogue;
    public Timer timer;
    public GameObject timerUI;
    //falta agregar que si tienes la planta detox se descontamina
    public AudioClip contaminado;
    //agregar que cuando se descontamine haya un segundo dialogo


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TriggerDialogue();
            timer.StartTimer(); // Start the timer
            timerUI.SetActive(true);
            if (contaminado != null)
            {
                AudioManager.instance.PlayMusic(contaminado);
            }
            // Add any other necessary actions here
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

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private bool IsAnyOtherReasonToPlayMusic() {
        return false;
    }
}
