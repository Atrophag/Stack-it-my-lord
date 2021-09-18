using System;
using UnityEngine;

public class GameScore
{
    public GameObject scoreTextObject;
    public GameObject maxScoreTextObject;
    private int maxScore = 0; 

    public void Initialize()
    {
        scoreTextObject = GameObject.Find("GameScore");
        maxScoreTextObject = GameObject.Find("GameMaxScore");
    }

    public void SetScore(int score)
    {
        maxScore = score > maxScore ? score : maxScore;

        string scoreText = String.Format("Score: {0}", score.ToString());
        string maxScoreText = String.Format("Max: {0}", maxScore.ToString());

        scoreTextObject.GetComponent<UnityEngine.UI.Text>().text = scoreText;
        maxScoreTextObject.GetComponent<UnityEngine.UI.Text>().text = maxScoreText;
    }
}
