using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controls the scoreboard.
/// </summary>
public class ScoreBehavior : MonoBehaviour
{
    /// <summary>
    /// Holds the global score that can be manipulated in other classes.
    /// </summary>
    public static int Score;
    /// <summary>
    /// Holds the internal score that is only used in this class.
    /// </summary>
    public int InternalScore;

    /// <summary>
    /// Displays the score.
    /// </summary>
    public GameObject ScoreDisplay;

    /// <summary>
    /// Updates once per frame.
    /// </summary>
    void Update()
    {
        //Set the internal score to be equal to Score
        InternalScore = Score;
        //Set text to display the score
        ScoreDisplay.GetComponent<Text>().text = "Score: " + InternalScore;
    }
}
