using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBehavior : MonoBehaviour
{
    public GameObject spawnObject;
    public Transform behaviorTarget;

    static float timeInterval = 8.0f;
    static float timeRemaining = 0.0f;

    // Update is called once per frame
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

    static float GetTimeInterval()
    {
        return timeInterval;
    }

    static void SetTimeInterval(float newTimeInterval)
    {
        timeInterval = newTimeInterval;
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
