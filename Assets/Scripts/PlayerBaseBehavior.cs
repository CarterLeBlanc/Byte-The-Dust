using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseBehavior : MonoBehaviour
{
    //Default player stats
    static float playerMaxHealth = 100.0f;
    static float playerCurrentHealth = 100.0f;
    static float playerDamage = 5.0f;
    static float playerSpeed = 3.0f;
    static float playerAttackRate = 2.0f;

    //Get the player's max health
    static public float GetPlayerMaxHealth()
    {
        return playerMaxHealth;
    }

    //Set the player's max health
    static public void SetPlayerMaxHealth(float newMaxHealth)
    {
        playerMaxHealth = newMaxHealth;
    }

    //Get the player's current health
    static public float GetPlayerCurrentHealth()
    {
        return playerCurrentHealth;
    }

    //Set the player's current health
    static public void SetPlayerCurrentHealth(float newCurrentHealth)
    {
        playerCurrentHealth = newCurrentHealth;
    }

    //Get the player's damage
    static public float GetPlayerDamage()
    {
        return playerDamage;
    }

    //Set the player's damage
    static public void SetPlayerDamaage(float newDamage)
    {
        playerDamage = newDamage;
    }

    //Get the player's speed
    static public float GetPlayerSpeed()
    {
        return playerSpeed;
    }

    //Set the player's speed
    static public void SetPlayerSpeed(float newSpeed)
    {
        playerSpeed = newSpeed;
    }

    //Get the player's attack rate
    static public float GetPlayerAttackRate()
    {
        return playerAttackRate;
    }

    //Set the player's attack rate
    static public void SetPlayerAttackRate(float newAttackRate)
    {
        playerAttackRate = newAttackRate;
    }
}
