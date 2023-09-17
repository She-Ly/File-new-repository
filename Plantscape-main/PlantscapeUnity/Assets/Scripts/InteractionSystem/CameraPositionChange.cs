using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionChange : MonoBehaviour
{
    public Transform player; // Arrastra el jugador aquí en el Inspector
    public Transform cameraPivot; // Arrastra el GameObject "Camera Pivot" aquí en el Inspector
    public float cameraYPivotPosition = 0f; // Valor de la posición Y deseada para el "Camera Pivot"

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Cambia la posición Y del "Camera Pivot"
            Vector3 newPivotPosition = cameraPivot.position;
            newPivotPosition.y = cameraYPivotPosition;
            cameraPivot.position = newPivotPosition;
        }
    }
}
