using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportDestination; // Arrastra el GameObject de destino aqu� en el Inspector
    public float teleportDelay = 2f; // Tiempo de espera antes de la teletransportaci�n
    private bool canTeleport = true;
    public AudioClip transportador;

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el jugador ha entrado en el �rea del objeto y puede teletransportarse
        if (canTeleport && other.CompareTag("Player"))
        {
            // Teletransporta al jugador al destino despu�s del tiempo de espera configurado
            Invoke("TeleportPlayerDelayed", teleportDelay);
            if (transportador != null)
            {
                AudioManager.instance.PlaySoundEffect(transportador);
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Cancela la teletransportaci�n si el jugador sale del �rea antes de que ocurra la teletransportaci�n
        if (other.CompareTag("Player"))
        {
            CancelInvoke("TeleportPlayerDelayed");
        }
    }

    public void TeleportPlayerDelayed()
    {
        // Teletransporta al jugador al destino
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.transform.position = teleportDestination.position;
        }

        // Reinicia el estado de teletransportaci�n
        canTeleport = true;
    }
}

