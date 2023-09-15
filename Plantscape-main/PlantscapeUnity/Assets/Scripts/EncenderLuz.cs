using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncenderLuz : MonoBehaviour
{
    public Light pointLight;
    private bool touchingCapsule;

    private void Start()
    {
        touchingCapsule = false;
        // Asegúrate de que el Point Light esté apagado al inicio
        pointLight.enabled = false;
    }

    private void Update()
    {
        if (touchingCapsule && Input.GetKeyDown(KeyCode.L))
        {
            // Encender la luz y establecer un tiempo para apagarla
            pointLight.enabled = true;
            Invoke("ApagarLuz", 5f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Capsule"))
        {
            touchingCapsule = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Capsule"))
        {
            touchingCapsule = false;
        }
    }

    private void ApagarLuz()
    {
        // Apagar la luz después de 10 segundos
        pointLight.enabled = false;
    }
}
