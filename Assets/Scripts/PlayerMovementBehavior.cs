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
        LookAtMouse();

        Vector3 moveDirection = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            //Up
            moveDirection += new Vector3(0, 0, 1);
        }

        if (Input.GetKey(KeyCode.A))
        {
            //Left
            moveDirection += new Vector3(-1, 0, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            //Down
            moveDirection += new Vector3(0, 0, -1);
        }

        if (Input.GetKey(KeyCode.D))
        {
            //Right
            moveDirection += new Vector3(1, 0, 0);
        }

        //Normalize the movement
        moveDirection.Normalize();

        moveDirection *= speed;

        controller.Move(moveDirection * Time.deltaTime);
    }

    void LookAtMouse()
    {
        //Get the position of the player
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

        //Get the position of the mouse
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //Get the angle between the two points
        float angle = GetAngleBetweenPoints(positionOnScreen, mouseOnScreen);

        transform.rotation = Quaternion.Euler(new Vector3(0f, -angle, 0f));
    }

    float GetAngleBetweenPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}