using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using UnityEngine.AI;

public class PlayerMovementBehavior : MonoBehaviour
{
    [SerializeField]

    private NavMeshAgent nav;
    float speed;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        speed = GameObject.Find("Player").GetComponent<PlayerBaseBehavior>().playerSpeed;
    }

    // Update is called once per frame
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

        //Set the magnitude
        movement *= speed;

        //Move
        nav.destination = transform.position + movement;
    }
}