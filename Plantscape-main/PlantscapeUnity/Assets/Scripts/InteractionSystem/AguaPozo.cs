using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AguaPozo : MonoBehaviour
{
    public Dialogue dialogue;

    public WaterManager waterManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TriggerDialogue();
            waterManager.RefillWater();
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

}
