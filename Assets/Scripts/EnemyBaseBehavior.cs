using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Holds the base values for the enemy.
/// </summary>
public class EnemyBaseBehavior : MonoBehaviour
{
    /// <summary>
    /// Holds the enemy's current health.
    /// </summary>
    public float enemyCurrentHealth = 10.0f;
    /// <summary>
    /// Holds the enemy's damage.
    /// </summary>
    public float enemyDamage = 5.0f;
    /// <summary>
    /// Holds the enemy's attack rate.
    /// </summary>
    public float enemyAttackRate = 1.0f;
}
