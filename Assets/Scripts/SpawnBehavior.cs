using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawns in entities.
/// </summary>
public class SpawnBehavior : MonoBehaviour
{
    /// <summary>
    /// Holds the object that will be spawned.
    /// </summary>
    public GameObject spawnObject;
    /// <summary>
    /// Holds the spawned entity's target.
    /// </summary>
    public Transform behaviorTarget;

    /// <summary>
    /// Holds the amount of time between entity spawns.
    /// </summary>
    static float timeInterval = 8.0f;
    /// <summary>
    /// Holds the amount of time before the next entity will spawn.
    /// </summary>
    static float timeRemaining = 0.0f;

    /// <summary>
    /// Updates once per frame.
    /// </summary>
    void Update()
    {
        //Decrement remaining time
        timeRemaining -= Time.deltaTime;

        //If there is no time remaining...
        if (timeRemaining <= 0 )
        {
            //Reset the timer
            timeRemaining = timeInterval;
            //And spawn an instance
            SpawnInstance();
        }
    }   

    /// <summary>
    /// Spawns an instance of a chosen entity.
    /// </summary>
    void SpawnInstance()
    {
        //Spawn an instance of spawnObject
        GameObject spawnedInstance = Instantiate(spawnObject, transform.position, transform.rotation);
        //Set the EnemyMovementBehavior's target to behaviorTarget
        EnemyMovementBehavior enemyMovementBehavior = spawnedInstance.GetComponent<EnemyMovementBehavior>();

        if (enemyMovementBehavior != null)
        {
            enemyMovementBehavior.target = behaviorTarget;
        }
    }
}
