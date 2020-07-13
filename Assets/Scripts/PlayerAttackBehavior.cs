using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Contains all functions needed for the player to engage in combat.
/// </summary>
public class PlayerAttackBehavior : MonoBehaviour
{

    [SerializeField]
    /// <summary>
    ///creates the character controller
    /// </summary>
    private CharacterController controller;
    /// <summary>
    ///creates the player animator
    /// </summary>
    public PlayerAnimator animator;

    /// <summary>
    ///creates the attack point and range of the player
    /// </summary>
    public Transform attackPoint;
    public float attackRange = 0.5f;

    /// <summary>
    ///creates the layer mask the player attacks
    /// </summary>
    public LayerMask enemyLayer;

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
    void Start()
    {
        currentHealth = GameObject.Find("Player").GetComponent<PlayerBaseBehavior>().playerCurrentHealth;
        attack = GameObject.Find("Player").GetComponent<PlayerBaseBehavior>().playerDamage;
        attackRate = GameObject.Find("Player").GetComponent<PlayerBaseBehavior>().playerAttackRate;
    }

    /// <summary>
    ///keeps the player from spamming the attack button to kill enemies
    /// </summary>
    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    /// <summary>
    ///the player takes damage if hit
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
    ///If the player dies
    /// </summary>
    public void Die()
    {
        Debug.Log("Player Died");

        animator.Death();

        GetComponent<Collider>().enabled = false;
        GetComponent<PlayerMovementBehavior>().enabled = false;

        StartCoroutine(RemovePlayerAfterTime(3.0f));
    }

    /// <summary>
    ///when the player goes to attack
    /// </summary>
    void Attack()
    {
        //Detect enemies in range of attack
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayer);

        animator.Attack();
        //Damage enemies
        foreach (Collider enemy in hitEnemies)
        {
            Debug.Log("Attacked enemy");
            enemy.GetComponent<EnemyAttackBehavior>().TakeDamage(attack);
        }

    }

    /// <summary>
    ///allows the player animation to play before going to the end screen
    /// </summary>
    IEnumerator RemovePlayerAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);

        SceneManager.LoadScene(3);
        ScoreBehavior.Score = 0;
    }

    /// <summary>
    ///creates the gizmo that is the attack point
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}