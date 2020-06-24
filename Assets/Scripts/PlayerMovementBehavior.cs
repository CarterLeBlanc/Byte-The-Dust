using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class PlayerMovementBehavior : MonoBehaviour
{
    [SerializeField]
    private CharacterController controller;

    private float speed = 3.0f;

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = new Vector3(0, 0, 0);

        //Move up
        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += new Vector3(0, 0, 1);
        }

        //Move down
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection += new Vector3(0, 0, -1);
        }

        //Move left
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection += new Vector3(-1, 0, 0);
        }
         //Mvoe right
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += new Vector3(1, 0, 0);
        }

        //Normalize the movement
        moveDirection.Normalize();

        moveDirection *= speed;

        controller.Move(moveDirection * Time.deltaTime);
    }
}
