using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBehavior : MonoBehaviour
{
    public static int Score;
    public int InternalScore;

    public GameObject ScoreDisplay;

    // Update is called once per frame
    void Update()
    {
        //Set the internal score to be equal to Score
        InternalScore = Score;
        //Set text to display the score
        ScoreDisplay.GetComponent<Text>().text = "Score: " + InternalScore;
    }
}
