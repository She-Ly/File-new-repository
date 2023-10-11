using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    private Animator animator;
    public AudioClip pasos;
    private Vector3 initialCameraPosition;
    //public AudioClip pasos;
    private bool isMoving = false;
    public float minMoveThreshold = 0.1f;
    private AudioSource audioSource;

    Rigidbody rb;
    public float climbSpeed = 0.07f;
    public LayerMask groundLayer;
    public Timer timer;
    public enum PlayerState
    {
        Walking,
        Climbing
    }

    public PlayerState currentState = PlayerState.Walking; // Default state is walking

    void Start()
    {
        animator = GetComponent<Animator>();
        initialCameraPosition = Camera.main.transform.position;
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false;

        rb = GetComponent<Rigidbody>();
    }

    void Update()
{
    if (currentState == PlayerState.Walking)
    {
            if (timer.looser) {
                return;
            }

        // Handle walking logic
        HandleWalking();
    }
    else if (currentState == PlayerState.Climbing)
    {
        // Handle climbing logic
        HandleClimbing();

    }

}


    private void HandleWalking()
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
            if (movement.magnitude > minMoveThreshold)
            {
                if (!isMoving)
                {
                    AudioManager.instance.PlaySoundEffect(pasos);
                    isMoving = true;
                }
            }
            else
            {
                //AudioManager.instance.PlaySoundEffect(pasos);
                isMoving = false;
            }
        }
        else
        {
            isMoving = false;
        }


        animator.SetFloat("MoveDirection", moveDirection);

        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }

    private void HandleClimbing()
{
    float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector2 input = SquareToCircle(new Vector2(h, v));

        if (rb)
        {
            rb.velocity = transform.TransformDirection(input) * speed;
        }
    }

    Vector2 SquareToCircle(Vector2 input)
    {
        return (input.sqrMagnitude >= 1f) ? input.normalized : input;
    }


    // Method to set the player's state
    public void SetState(PlayerState newState)
    {
        // Ensure you perform any necessary state-specific setup or cleanup here.

        currentState = newState;

        // Depending on the state, you might want to disable certain behaviors/animations or enable others.
        // For example, you might want to disable walking animations when climbing.

        if (newState == PlayerState.Climbing)
        {
        }
        else if (newState == PlayerState.Walking)
        {
        }
    }

    public bool IsGrounded()
{
    Collider playerCollider = GetComponent<Collider>();
    
    // Calculate a small offset above the player's feet.
    float offset = 0.1f; // Adjust this offset based on your character's size.

    // Create a sphere to check for ground at the player's feet.
    Vector3 sphereCenter = transform.position + Vector3.up * offset;
    float sphereRadius = playerCollider.bounds.extents.x * 0.9f; // Use half of the collider's width as the radius.

    // Use SphereCast to check for ground.
    RaycastHit hit;
    if (Physics.SphereCast(sphereCenter, sphereRadius, Vector3.down, out hit, offset + 1f, groundLayer))
    {
        return true;
    }
    
    return false;
}

    public void ChangeCatSprites()
    {
        animator.SetLayerWeight(0, 0f); // Layer without cat (inactive)
        animator.SetLayerWeight(1, 1f); // Layer with cat (active)

    }

  
}

