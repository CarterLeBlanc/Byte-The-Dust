using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButtonBehaviour : MonoBehaviour
{
    public void CloseGame()
    {
        Application.Quit();
        Debug.Log("Close");
    }
}