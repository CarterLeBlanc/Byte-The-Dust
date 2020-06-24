using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackBehavior : MonoBehaviour
{
    [SerializeField]
    private CharacterController controller;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;

    private float maxHealth = PlayerBaseBehavior.GetPlayerMaxHealth();
    private float currentHealth = PlayerBaseBehavior.GetPlayerCurrentHealth();


    private float attack = PlayerBaseBehavior.GetPlayerDamage();
    private float attackRate = PlayerBaseBehavior.GetPlayerAttackRate();
    float nextAttackTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //NOTICE: ATTACK DOES DOUBLE DAMAGE! NEEDS TO BE FIXED
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player Died");

        GetComponent<Collider>().enabled = false;
        GetComponent<PlayerMovementBehavior>().enabled = false;
        this.enabled = false;
    }

    void Attack()
    {
        //Detect enemies in range of attack
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayer);

        //Damage enemies
        foreach (Collider enemy in hitEnemies)
        {
            Debug.Log("Attacked enemy");
            enemy.GetComponent<EnemyAttackBehavior>().TakeDamage(attack);
        }

    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}