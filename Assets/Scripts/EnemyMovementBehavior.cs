using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class EnemyMovementBehavior : MonoBehaviour
{
    [SerializeField]
    private CharacterController controller;

    public Transform target;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = GameObject.Find("Enemy").GetComponent<EnemyBaseBehavior>().enemySpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //Find the direction
        Vector3 movement = new Vector3(0, 0, 0);
        if (target != null)
        {
            movement = target.position - transform.position;
            movement.Normalize();
        }

        //Set the magnitude
        movement *= speed;

        //Move
        controller.Move(movement * Time.deltaTime);
    }
}