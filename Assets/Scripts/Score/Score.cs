using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private int pointsPerSecond = 10;
    private int score = 0;
    private float timeSinceLastUpdate = 0f;


    private void Update()
    {
      timeSinceLastUpdate += Time.deltaTime;

        if(timeSinceLastUpdate >= 1f)
        {
            UpdateScore();
            timeSinceLastUpdate = 0f;
        }

        scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();

    }

    public int GetScore()
    {
        return score;
    }

    private void UpdateScore()
    {
        Debug.Log("Score Update");
        score += pointsPerSecond;
    }

    public void AddScore(int points)
    {
        score += points;
        
    }
}
