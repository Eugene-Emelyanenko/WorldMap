using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text maxScoreText;
    [SerializeField] private Text gameOverScoreText;
    private int maxScore;
    private int score;
    void Start()
    {
        maxScore = PlayerPrefs.GetInt("maxScore", 0);
        maxScoreText.text = maxScore.ToString();
        score = 0;
        scoreText.text = score.ToString();
        gameOverScoreText.text = score.ToString();
    }

    public void IncreaseScore()
    {
        score++;

        if (score > maxScore)
        {
            maxScore = score;
            PlayerPrefs.SetInt("maxScore", maxScore);
            maxScoreText.text = maxScore.ToString();
        }

        gameOverScoreText.text = score.ToString();
        scoreText.text = score.ToString();
    }
}
