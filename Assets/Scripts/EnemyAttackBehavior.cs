using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackBehavior : MonoBehaviour
{

    public float attack = 10.0f;
    public float maxHealth = 20.0f;
    public float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy Died");

        GetComponent<Collider>().enabled = false;
        GetComponent<EnemyMovementBehavior>().enabled = false;
        this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
