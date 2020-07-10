using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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