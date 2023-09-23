using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AguaPozo : MonoBehaviour
{
    public Dialogue dialogue;

    public WaterManager waterManager;
    public AudioClip Inundado;
    public AudioClip splash;
    public AudioSource AudioSource;

    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TriggerDialogue();
            waterManager.RefillWater();

            if (Inundado != null)
            {
                AudioManager.instance.PlayMusic(Inundado);
            }
            if (splash != null)
            {
                AudioManager.instance.PlaySoundEffect(splash);
            }
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!IsAnyOtherReasonToPlayMusic())
            {
                AudioManager.instance.PlayBackgroundMusic();
                //AudioManager.instance.PauseMusic(contaminado);
            }

        }
    }
    private bool IsAnyOtherReasonToPlayMusic()
    {
        return false;
    }
}

