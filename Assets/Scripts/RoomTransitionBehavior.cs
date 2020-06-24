using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomTransitionBehavior : MonoBehaviour
{
    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        Debug.Log("Scene Changed.");
    //        LoadNextScene();
    //    }
    //}

    //Check if the player reaches the transition point.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LoadNextScene();
        }
    }

    //Load the next level.
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
