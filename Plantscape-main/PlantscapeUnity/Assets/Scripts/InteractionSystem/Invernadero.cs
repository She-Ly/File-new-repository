using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invernadero : MonoBehaviour
{
    public Dialogue dialogue;

    private bool firstInteraction = true;
    public AudioClip invernadero;
    public AudioClip mauw;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(firstInteraction)
            {
                TriggerDialogue();
                //sonido del gato
                if (mauw != null)
                {
                    AudioManager.instance.PlaySoundEffect(mauw);
                }

                // Reproduce la música de fondo del invernadero
                if (invernadero != null)
                {
                    AudioManager.instance.PlayMusic(invernadero);
                }
                firstInteraction = false;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
