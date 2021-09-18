using System;
using UnityEngine;

public class GameScore
{
    public GameObject textObject;
    public string textFormat = "Score: {0}";

    public void Initialize()
    {
        textObject = GameObject.Find("GameScore");
    }

    public void SetScore(int score)
    {
        string scoreText = String.Format(textFormat, score.ToString());
        textObject.GetComponent<UnityEngine.UI.Text>().text = scoreText;
    }
}
