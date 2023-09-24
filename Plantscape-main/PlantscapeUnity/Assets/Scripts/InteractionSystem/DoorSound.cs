using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSound : MonoBehaviour
{
    // Agrega un campo para el efecto de sonido de apertura en el Inspector
    public AudioClip abrirPuerta;

    private bool hasPlayedSound = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasPlayedSound)
        {
            // Reproduce el sonido de apertura de la puerta
            if (abrirPuerta != null)
            {
                AudioManager.instance.PlaySoundEffect(abrirPuerta);
            }
            hasPlayedSound = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !hasPlayedSound)
        {
            if (abrirPuerta != null)
            {
                AudioManager.instance.PlaySoundEffect(abrirPuerta);
            }
            hasPlayedSound = true;

        }
    }
   
   
}
