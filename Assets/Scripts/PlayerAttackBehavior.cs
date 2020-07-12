﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAttackBehavior : MonoBehaviour
{
    [SerializeField]
    private CharacterController controller;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;

    float currentHealth;


    float attack;
    float attackRate;
    float nextAttackTime = 0f;

    void Start()
    {
        currentHealth = GameObject.Find("Player").GetComponent<PlayerBaseBehavior>().playerCurrentHealth;
        attack = GameObject.Find("Player").GetComponent<PlayerBaseBehavior>().playerDamage;
        attackRate = GameObject.Find("Player").GetComponent<PlayerBaseBehavior>().playerAttackRate;
    }

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

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Player Died");

        DeletePlayerAfterTime(3.0f);

        SceneManager.LoadScene(3);
        ScoreBehavior.Score = 0;
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

    IEnumerator DeletePlayerAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        GetComponent<Collider>().enabled = false;
        GetComponent<PlayerMovementBehavior>().enabled = false;
        this.enabled = false;
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}