using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Holds the player's stats.
/// </summary>
public class PlayerBaseBehavior : MonoBehaviour
{
    /// <summary>
    /// Holds the player's max health.
    /// </summary>
    public float playerMaxHealth = 100.0f;
    /// <summary>
    /// Holds the player's current health.
    /// </summary>
    public float playerCurrentHealth = 100.0f;
    /// <summary>
    /// Holds the player's damage.
    /// </summary>
    public float playerDamage = 5.0f;
    /// <summary>
    /// Holds the player's attack rate.
    /// </summary>
    public float playerAttackRate = 2.0f;
}
