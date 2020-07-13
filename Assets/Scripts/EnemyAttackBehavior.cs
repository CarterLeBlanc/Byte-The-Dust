
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains all functions needed for the enemy to engage in combat.
/// </summary>
public class EnemyAttackBehavior : MonoBehaviour
{
    /// <summary>
    ///creates the player animator
    /// </summary>
    public EnemyAnimator animator;

    /// <summary>
    ///creates the attack point and range of the enemy
    /// </summary>
    public Transform enemyAttackPoint;
    public float attackRange = 0.5f;

    /// <summary>
    ///creates the layer mask the enemy attacks
    /// </summary>
    public LayerMask playerLayer;

    /// <summary>
    ///sets the current health
    /// </summary>
    float currentHealth;

    /// <summary>
    ///the attack and attack rate
    /// </summary>
    float attack;
    float attackRate;
    float nextAttackTime = 0f;

    /// <summary>
    ///sets the current health, the attack, and the attack rate to the base class
    /// </summary>
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = GameObject.Find("Enemy").GetComponent<EnemyBaseBehavior>().enemyCurrentHealth;
        attack = GameObject.Find("Enemy").GetComponent<EnemyBaseBehavior>().enemyDamage;
        attackRate = GameObject.Find("Enemy").GetComponent<EnemyBaseBehavior>().enemyAttackRate;
    }

    /// <summary>
    ///keeps the enemy from spamming the attack
    /// </summary>
    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }

    /// <summary>
    ///the enemy takes damage if hit
    /// </summary>
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    /// <summary>
    ///If the enemy dies
    /// </summary>
    void Die()
    {
        Debug.Log("Enemy Died");
        animator.Death();
        ScoreBehavior.Score += 10;

        GetComponent<Collider>().enabled = false;
        GetComponent<EnemyMovementBehavior>().enabled = false;
        
        StartCoroutine(RemoveEnemyAfterTime(3.0f));
    }

    /// <summary>
    ///when the enemy goes to attack
    /// </summary>
    void Attack()
    {
        ////Detect player in range
        Collider[] hitPlayer = Physics.OverlapSphere(enemyAttackPoint.position, attackRange, playerLayer);

        animator.Attack();

        //Damage player
        foreach (Collider player in hitPlayer)
        {
            player.GetComponent<PlayerAttackBehavior>().TakeDamage(attack);
            Debug.Log("Attacked player");
        }

    }

    /// <summary>
    ///allows the enemy to exist for a moment before despawning
    /// </summary>
    IEnumerator RemoveEnemyAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }

    /// <summary>
    ///creates the gizmo that is the attack point
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        if (enemyAttackPoint == null)
            return;
        Gizmos.DrawWireSphere(enemyAttackPoint.position, attackRange);
    }
}