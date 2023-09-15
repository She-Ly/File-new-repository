using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    private Animator animator;

    private Vector3 initialCameraPosition;
    public AudioClip pasos;

    void Start()
    {
        animator = GetComponent<Animator>();
        initialCameraPosition = Camera.main.transform.position;
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calculate movement direction based on camera's initial position
        Vector3 cameraToPlayer = transform.position - initialCameraPosition;
        cameraToPlayer.y = 0f;
        Vector3 cameraForward = Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up);
        Vector3 cameraRight = Vector3.Cross(Vector3.up, cameraForward);

        Vector3 movement = (cameraForward * moveVertical + cameraRight * moveHorizontal).normalized;

        float moveDirection = -1.0f; // Default value for no movement

        if (movement != Vector3.zero)
        {
            if (moveHorizontal > 0)
                moveDirection = 1.0f; // Right
            else if (moveHorizontal < 0)
                moveDirection = 3.0f; // Left
            else if (moveVertical > 0)
                moveDirection = 2.0f; // Up
            else if (moveVertical < 0)
                moveDirection = 4.0f; // Down
            if (pasos != null)
            {
                AudioManager.instance.PlaySoundEffect(pasos);
            }
        }

        animator.SetFloat("MoveDirection", moveDirection);

        transform.Translate(movement * speed * Time.deltaTime, Space.World);

    }


}
