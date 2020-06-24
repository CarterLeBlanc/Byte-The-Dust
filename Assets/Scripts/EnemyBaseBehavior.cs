using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseBehavior : MonoBehaviour
{
    static float enemyMaxHealth = 10.0f;
    static float enemyCurrentHealth = 10.0f;
    static float enemyDamage = 5.0f;
    static float enemySpeed = 1.0f;
    static float enemyAttackRate = 1.0f;

    //Get the enemy's max health
    static public float GetEnemyMaxHealth()
    {
        return enemyMaxHealth;
    }

    //Set the enemy's max health
    static public void SetEnemyMaxHealth(float newMaxHealth)
    {
        enemyMaxHealth = newMaxHealth;
    }

    //Get the enemy's current health
    static public float GetEnemyCurrentHealth()
    {
        return enemyCurrentHealth;
    }

    //Set the enemy's current health
    static public void SetEnemyCurrentHealth(float newCurrentHealth)
    {
        enemyCurrentHealth = newCurrentHealth;
    }

    //Get the enemy's damage
    static public float GetEnemyDamage()
    {
        return enemyDamage;
    }

    //Set the enemy's damage
    static public void SetEnemyDamaage(float newDamage)
    {
        enemyDamage = newDamage;
    }

    //Get the enemy's speed
    static public float GetEnemySpeed()
    {
        return enemySpeed;
    }

    //Set the enemy's speed
    static public void SetEnemySpeed(float newSpeed)
    {
        enemySpeed = newSpeed;
    }

    //Get the enemy's attack rate
    static public float GetEnemyAttackRate()
    {
        return enemyAttackRate;
    }

    //Set the enemy's attack rate
    static public void SetEnemyAttackRate(float newAttackRate)
    {
        enemyAttackRate = newAttackRate;
    }
}
