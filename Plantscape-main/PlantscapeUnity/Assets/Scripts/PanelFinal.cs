using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;


public class PanelFinal : MonoBehaviour

{
    public AudioClip yei;

    public GameObject panelFinal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("Player"))

        {
            panelFinal.SetActive(true);
            if (yei != null)
            {
                AudioManager.instance.PlayMusic(yei);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Add any necessary actions when the player exits the trigger zone
            
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
