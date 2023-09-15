using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public GameObject cam;
    public float fixedXRotation = 0f; // Set this value to the desired fixed X rotation angle.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the rotation needed to look at the camera while keeping the X rotation fixed.
        Quaternion targetRotation = Quaternion.LookRotation(cam.transform.position - transform.position);
        targetRotation.eulerAngles = new Vector3(fixedXRotation, targetRotation.eulerAngles.y, targetRotation.eulerAngles.z);

        // Apply the rotation to the sprite.
        transform.rotation = targetRotation;
    }
}
