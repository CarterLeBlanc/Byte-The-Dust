using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBehavior : MonoBehaviour
{
    public GameObject spawnObject;
    public Transform behaviorTarget;

    static float timeInterval = 5.0f;
    static float timeRemaining = 0.0f;
    static float numberSpawned = 0.0f;
    static float spawnLimit = 5.0f;

    // Update is called once per frame
    void Update()
    {
        //Decrement remaining time
        timeRemaining -= Time.deltaTime;

        //If there is no time remaining...
        if (timeRemaining <= 0 && numberSpawned < spawnLimit)
        {
            //Reset the timer
            timeRemaining = timeInterval;
            //Increase numberSpawned
            numberSpawned++;
            //And spawn an instance
            SpawnInstance();
        }
    }

    static float GetTimeInterval()
    {
        return timeInterval;
    }

    static void SetTimeInterval(float newTimeInterval)
    {
        timeInterval = newTimeInterval;
    }

    static float GetSpawnLimit()
    {
        return spawnLimit;
    }

    static void SetSpawnLimit(float newSpawnLimit)
    {
        spawnLimit = newSpawnLimit;
    }

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
