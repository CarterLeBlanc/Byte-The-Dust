
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackBehavior : MonoBehaviour
{

    public Transform enemyAttackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayer;

    float currentHealth;

    float attack;
    float attackRate;
    float nextAttackTime = 0f;



    // Start is called before the first frame update
    void Start()
    {
        currentHealth = GameObject.Find("Enemy").GetComponent<EnemyBaseBehavior>().enemyCurrentHealth;
        attack = GameObject.Find("Enemy").GetComponent<EnemyBaseBehavior>().enemyDamage;
        attackRate = GameObject.Find("Enemy").GetComponent<EnemyBaseBehavior>().enemyAttackRate;
    }


    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
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
        ScoreBehavior.Score += 10;

        DeleteEnemyAfterTime(3.0f);
    }


    void Attack()
    {
        ////Detect player in range
        Collider[] hitPlayer = Physics.OverlapSphere(enemyAttackPoint.position, attackRange, playerLayer);

        //Damage player
        foreach (Collider player in hitPlayer)
        {

            player.GetComponent<PlayerAttackBehavior>().TakeDamage(attack);
            Debug.Log("Attacked player");
        }

    }

    IEnumerator DeleteEnemyAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        GetComponent<Collider>().enabled = false;
        GetComponent<EnemyMovementBehavior>().enabled = false;
        this.enabled = false;
    }

    private void OnDrawGizmosSelected()
    {
        if (enemyAttackPoint == null)
            return;
        Gizmos.DrawWireSphere(enemyAttackPoint.position, attackRange);
    }
}