using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using UnityEngine.AI;

/// <summary>
/// Controls the player's movement.
/// </summary>
public class PlayerMovementBehavior : MonoBehaviour
{
    [SerializeField]

    /// <summary>
    /// Holds the navmesh agent.
    /// </summary>
    private NavMeshAgent nav;

    /// <summary>
    /// Holds the player animator.
    /// </summary>
    public PlayerAnimator animator;

    /// <summary>
    /// Sets variables when the game starts.
    /// </summary>
    void Start()
    {
        //Set nav to the navmesh agent
        nav = GetComponent<NavMeshAgent>();
    }

    /// <summary>
    /// Updates once per frame.
    /// </summary>
    void Update()
    {
        //Find the direction
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        
        //Rotate the player to face the direction it is moving in
        transform.rotation = Quaternion.LookRotation(movement);

        //Normalize the movement
        movement.Normalize();

        //Move
        nav.destination = transform.position + movement;
        animator.speed = nav.desiredVelocity.magnitude / nav.speed;
    }
}