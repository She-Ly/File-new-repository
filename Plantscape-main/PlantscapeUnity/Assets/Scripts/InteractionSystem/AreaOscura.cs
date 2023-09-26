using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaOscura : MonoBehaviour
{
    public Dialogue dialogue;
    public Dialogue secondDialogue;

    public AudioClip oscuro;

    public Inventory inventory;
    public PlantaLista planta;

    private bool isDialogueInProgress = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (inventory != null && inventory.HasItem(planta.plantaItem))
            {
                StartCoroutine(TriggerAndHandleDialogue(secondDialogue));
                Destroy(gameObject);
                inventory.UseItem(planta.plantaItem);
                //animacion de planta luz
            }
            else
            {
                StartCoroutine(TriggerAndHandleDialogue(dialogue));
                if (oscuro != null)
                {
                    AudioManager.instance.PlayMusic(oscuro);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
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
