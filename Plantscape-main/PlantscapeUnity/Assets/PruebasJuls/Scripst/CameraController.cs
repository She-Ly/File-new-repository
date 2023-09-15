using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cameraPivot;
    public float rotationAmount = 45f;
    public float rotationSpeed = 5f; // Velocidad de rotación suave
    public float fixedXRotation = 30f; // Rotación constante en el eje X

    private Quaternion targetRotation;

    private void Start()
    {
        cameraPivot = new GameObject("CameraPivot").transform;
        targetRotation = Quaternion.Euler(fixedXRotation, transform.rotation.eulerAngles.y, 0f);
    }

    private void Update()
    {
        Quaternion targetRotationY = Quaternion.Euler(fixedXRotation, targetRotation.eulerAngles.y, 0f);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotationY, rotationSpeed * Time.deltaTime);
    }

    public void RotateCameraClockwise()
    {
        targetRotation *= Quaternion.Euler(0f, rotationAmount, 0f);
    }

    public void RotateCameraCounterClockwise()
    {
        targetRotation *= Quaternion.Euler(0f, -rotationAmount, 0f);
    }
}

