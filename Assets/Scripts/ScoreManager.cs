using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    public static int score;
    public static int highScore = 0;

    public Text scoreValue;
    public Text highScoreValue;

    // RectTransform to change Text position
    public RectTransform scoreTransform;
    public RectTransform highScoreTransform;

    void Awake () {
        highScore = PlayerPrefs.GetInt ("highScore");
        highScoreValue.text = highScore.ToString ();
        score = 0;
    }

    // Update is called once per frame
    void Update () {
        // Displays the score value in the Text component
        scoreValue.text = score.ToString ();
        if (scoreValue.text.Length > 10) {
            // Shrinks the font and moves the display down as the number gets larger
            scoreValue.fontSize = 30;
            scoreTransform.anchoredPosition = new Vector3 (137.2f, -75f, 0f);
        }

        // Sets the high score
        if (score > highScore) {
            highScore = score;
            // Displays the high score
            highScoreValue.text = highScore.ToString ();
            if (highScoreValue.text.Length > 4) {
                // Shrinks the text and moves it down to fit in the space for larger scores
                highScoreValue.fontSize = 30;
                highScoreTransform.anchoredPosition = new Vector3 (115.6f, -31f, 0);
            } else if (highScoreValue.text.Length > 2) {
                highScoreValue.fontSize = 20;
                highScoreTransform.anchoredPosition = new Vector3 (115.6f, -39f, 0);
            }

            // Stores the players's high score 
            PlayerPrefs.SetInt ("highScore", highScore);
        }
    }
}