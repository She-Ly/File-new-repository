using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpRoom : MonoBehaviour
{
    public AudioClip setRoom;
    //agregar que cuando se descontamine haya un segundo dialogo


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            if (setRoom != null)
            {
                AudioManager.instance.PlayMusic(setRoom);
            }
            // Add any other necessary actions here
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Add any necessary actions when the player exits the trigger zone
           // Hide the timer UI
            if (!IsAnyOtherReasonToPlayMusic())
            {
                AudioManager.instance.PlayBasemusic();
                //AudioManager.instance.PauseMusic(contaminado);
            }

        }
    }
    private bool IsAnyOtherReasonToPlayMusic()
    {
        return false;
    }
}
