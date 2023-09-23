using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterManager : MonoBehaviour
{
    public int maxWaterCount = 3; // Maximum water count
    public int waterCount = 0; 
    public Image[] waterDropIcons; // UI elements representing water drops

    public Dialogue dialogue; 
    public AudioClip emptyWaterSound; // archivo de sonido
    private AudioSource audioSource;
    public AudioClip addAgua;


    void Start()
    {
        waterCount = 0;
        audioSource = AudioManager.instance.soundEffectSource;
    }

    // Call this function to water a plant
    public void WaterPlant()
    {
        if (waterCount > 0)
        {
            // Deduct one water drop
            waterCount--;

            // Update the UI to reflect the new water count
            UpdateWaterUI();
        }
        else
        {
            if (emptyWaterSound != null)
            {
                audioSource.PlayOneShot(emptyWaterSound);
            }
            TriggerDialogue();
        }
    }

    // Call this function to refill the water supply
    public void RefillWater()
    {
        // Fully refill the water supply
        waterCount = maxWaterCount;
        if (addAgua != null)
        {
            AudioManager.instance.PlaySoundEffect(addAgua);
        }
        // Update the UI to reflect the full water supply
        UpdateWaterUI();
    }

    // Update the UI to show/hide water drop icons
    private void UpdateWaterUI()
    {
        for (int i = 0; i < waterDropIcons.Length; i++)
        {
            // Show or hide the water drop icons based on waterCount
            waterDropIcons[i].enabled = (i < waterCount);
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
