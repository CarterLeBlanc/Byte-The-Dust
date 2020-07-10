using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
