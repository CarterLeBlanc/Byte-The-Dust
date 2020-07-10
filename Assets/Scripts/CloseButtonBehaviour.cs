using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Closes the game when a button is clicked.
/// </summary>
public class CloseButtonBehaviour : MonoBehaviour
{
    /**
     * Once the button is clicked, the scene will close.
    **/
    public void CloseGame()
    {
        Application.Quit();
        Debug.Log("Close");
    }
}