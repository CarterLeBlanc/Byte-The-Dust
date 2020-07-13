using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    /// <summary>
    ///creates the animator
    /// </summary>
    private Animator animator;

    /// <summary>
    ///the speed function that adhears to the assets movement
    /// </summary>
    public float speed = 0.0f;

    // Start is called before the first frame update
    void Start()
    {        
        animator = GetComponent<Animator>();
    }

    /// <summary>
    ///The speed thats adjusted for how fast the assets is moving
    /// </summary>
    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", speed);      
    }

    /// <summary>
    ///The attack animation trigger
    /// </summary>
    public void Attack()
    {
        animator.SetTrigger("Attack");
    }

    /// <summary>
    ///the death animation trigger
    /// </summary>
    public void Death()
    {
        animator.SetTrigger("Death");
    }
}
