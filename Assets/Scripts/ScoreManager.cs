using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    public static int score;

    public int highScore = 0;

    public Text scoreValue;

    public Text highScoreValue;

    // RectTransform to change Text position

    void Awake () {
        // scoreValue = GetComponent<Text> ();
        highScore = PlayerPrefs.GetInt ("highScore");
        highScoreValue.text = highScore.ToString ();
        score = 0;
    }

    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        scoreValue.text = score.ToString ();
        if (scoreValue.text.Length > 10) {
            scoreValue.fontSize = 30;
            // scoreValue.transform.position.y = -75;
        }

        if (score > highScore) {
            highScore = score;
            highScoreValue.text = highScore.ToString ();
            if (highScoreValue.text.Length > 4) {
                highScoreValue.fontSize = 30;
            } else if (highScoreValue.text.Length > 6) {
                highScoreValue.fontSize = 20;
                // highScoreValue.transform.position.y = 269;
            }
            PlayerPrefs.SetInt ("highScore", highScore);
        }
    }
}