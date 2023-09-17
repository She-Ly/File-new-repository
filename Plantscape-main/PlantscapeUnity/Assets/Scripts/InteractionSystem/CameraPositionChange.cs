using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionChange : MonoBehaviour
{
    public Transform player; // Arrastra el jugador aqu� en el Inspector
    public Transform cameraPivot; // Arrastra el GameObject "Camera Pivot" aqu� en el Inspector
    public float cameraYPivotPosition = 0f; // Valor de la posici�n Y deseada para el "Camera Pivot"

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Cambia la posici�n Y del "Camera Pivot"
            Vector3 newPivotPosition = cameraPivot.position;
            newPivotPosition.y = cameraYPivotPosition;
            cameraPivot.position = newPivotPosition;
        }
    }
}
