using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class PlayerMovementBehavior : MonoBehaviour
{
    [SerializeField]
    private CharacterController controller;

    float speed;

    void Start()
    {
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
        controller.Move(movement * Time.deltaTime);
    }
}