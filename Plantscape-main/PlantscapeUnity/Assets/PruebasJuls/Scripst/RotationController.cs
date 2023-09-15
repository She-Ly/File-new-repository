using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    public Transform rotatingObject;
    public float rotationAmount = 90f; // Cantidad de rotación en grados

    public void RotateObject()
    {
        Vector3 currentRotation = rotatingObject.eulerAngles;
        rotatingObject.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y + rotationAmount, currentRotation.z);
    }

    public void RotateObjectBack()
    {
        Vector3 currentRotation = rotatingObject.eulerAngles;
        rotatingObject.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y - rotationAmount, currentRotation.z);
    }
}

