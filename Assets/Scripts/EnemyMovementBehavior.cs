using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(CharacterController))]

/// <summary>
/// Controls the enemy's movement.
/// </summary>
public class EnemyMovementBehavior : MonoBehaviour
{
    [SerializeField]

    /// <summary>
    /// Holds the enemy's target.
    /// </summary>
    public Transform target;
    /// <summary>
    /// Holds the enemy's navmesh.
    /// </summary>
    private NavMeshAgent nav;

    /// <summary>
    /// Holds the enemy animator.
    /// </summary>
    public EnemyAnimator animator;

    /// <summary>
    /// Sets variables when the game starts.
    /// </summary>
    void Start()
    {
        // Sets nav to the navmesh agent
        nav = GetComponent<NavMeshAgent>();
    }

    /// <summary>
    /// Updates once per frame.
    /// </summary>
    void Update()
    {
        //Set the enemies new destination to be the player's position
        nav.SetDestination(target.position);
        animator.speed = nav.desiredVelocity.magnitude / nav.speed;     
    }
}