using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportDestination; // Arrastra el GameObject de destino aquí en el Inspector
    public float teleportDelay = 2f; // Tiempo de espera antes de la teletransportación
    private bool canTeleport = true;
    public AudioClip transportador;



    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el jugador ha entrado en el área del objeto y puede teletransportarse
        if (canTeleport && other.CompareTag("Player"))
        {
            // Teletransporta al jugador al destino después del tiempo de espera configurado
            Invoke("TeleportPlayerDelayed", teleportDelay);
        }
        if (transportador != null)
        {
            AudioManager.instance.PlaySoundEffect(transportador);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Cancela la teletransportación si el jugador sale del área antes de que ocurra la teletransportación
        if (other.CompareTag("Player"))
        {
            CancelInvoke("TeleportPlayerDelayed");
        }
    }

    private void TeleportPlayerDelayed()
    {
        // Teletransporta al jugador al destino
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.transform.position = teleportDestination.position;
        }
        
        // Reinicia el estado de teletransportación
        canTeleport = true;
    }
}

