using System.Collections;
using System.Collections.Generic;
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
        Vector3 movement = new Vector3(0, 0, 0);
        movement += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //Normalize the movement
        movement.Normalize();

        //Set the magnitude
        movement *= speed;

        //Move
        controller.Move(movement * Time.deltaTime);
    }
}