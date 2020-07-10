using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Moves on to the next scene when a button is clicked.
/// </summary>
public class ClickButtonBehaviour : MonoBehaviour
{
    /**
     * Once the button is clicked, the scene will go to the next scene.
    **/
    public void LoadScene(int sceneBuildIndex)
    {
        SceneManager.LoadScene(sceneBuildIndex);
    }
}
