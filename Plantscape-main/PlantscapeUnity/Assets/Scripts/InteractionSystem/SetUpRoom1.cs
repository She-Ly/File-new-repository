using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpRoom1 : MonoBehaviour
{
    public AudioClip Room;
    private bool baseMusicPlaying;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Pausar la m�sica base si est� reproduci�ndose

            // Reproducir el audio de la sala
            if (Room != null)
            {
                AudioManager.instance.PlayMusic(Room);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Si la m�sica base estaba reproduci�ndose, reanudarla
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



