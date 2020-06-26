using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackBehavior : MonoBehaviour
{

    public Transform enemyAttackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayer;


    private float attack = EnemyBaseBehavior.GetEnemyDamage();
    private float maxHealth = EnemyBaseBehavior.GetEnemyMaxHealth();
    private float currentHealth = EnemyBaseBehavior.GetEnemyCurrentHealth();

    private float attackRate = EnemyBaseBehavior.GetEnemyAttackRate();
    float nextAttackTime = 0f;



    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {

            //NOTICE: ATTACK DOES DOUBLE DAMAGE! NEEDS TO BE FIXED
            Attack();
            nextAttackTime = Time.time + 1f / attackRate;

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
        Debug.Log("Enemy Died");

        GetComponent<Collider>().enabled = false;
        GetComponent<EnemyMovementBehavior>().enabled = false;
        this.enabled = false;
    }


    void Attack()
    {
        //Detect player in range
        Collider[] hitPlayer = Physics.OverlapSphere(enemyAttackPoint.position, attackRange, playerLayer);

        //Damage player
        foreach (Collider player in hitPlayer)
        {

            player.GetComponent<PlayerAttackBehavior>().TakeDamage(attack);
            Debug.Log("Attacked player");
        }

    }

    private void OnDrawGizmosSelected()
    {
        if (enemyAttackPoint == null)
            return;
        Gizmos.DrawWireSphere(enemyAttackPoint.position, attackRange);
    }


}