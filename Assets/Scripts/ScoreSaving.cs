using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSaving : MonoBehaviour
{
    public Text timeText;
    public Text scoreText;

    void Start()
    {

        float savedTime = PlayerPrefs.GetFloat("Time");
        int savedScore = PlayerPrefs.GetInt("Score");

        int minutes = Mathf.FloorToInt(savedTime / 60);
        int seconds = Mathf.FloorToInt(savedTime % 60);
        int milliseconds = Mathf.FloorToInt((savedTime * 100) % 100);

        string timerText = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
        timeText.text = timerText;

        scoreText.text = "Score: " + savedScore;
    }
}
