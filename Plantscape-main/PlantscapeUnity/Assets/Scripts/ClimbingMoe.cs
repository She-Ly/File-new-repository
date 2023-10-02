using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbingMoe : MonoBehaviour
{
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius = 0.07f;
    [SerializeField] private LayerMask _climbMask;
    [SerializeField] private Player _player; // Reference to the player script.

    private readonly Collider[] _colliders = new Collider[4];
    [SerializeField] private int _numFound;

    private void Start()
    {
        _player = GetComponent<Player>();
    }

    void Update()
    {
        _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders, _climbMask);

        if (_numFound > 0) // Check if the player is not grounded.
        {
            // Vine found, switch the player to climbing state.
            _player.SetState(Player.PlayerState.Climbing);
        }
        else
        {
            // Player is either grounded or not touching the vine, switch back to walking state.
            _player.SetState(Player.PlayerState.Walking);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
    }
}
