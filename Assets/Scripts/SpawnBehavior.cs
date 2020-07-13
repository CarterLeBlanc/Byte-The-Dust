using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawns entities into the scene.
/// </summary>
public class SpawnBehavior : MonoBehaviour
{
    /// <summary>
    /// Holds the object to be spawned in.
    /// </summary>
    public GameObject spawnObject;
    /// <summary>
    /// Holds the target of the spawned object.
    /// </summary>
    public Transform behaviorTarget;

    /// <summary>
    /// Time between entity spawns.
    /// </summary>
    static float timeInterval = 8.0f;
    /// <summary>
    /// Time until next entity is spawned.
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
    /// Spawns and instance of an entity.
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
