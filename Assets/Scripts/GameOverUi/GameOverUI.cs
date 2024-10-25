using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    public TextMeshProUGUI survivalTimeText;
    public TextMeshProUGUI totalScoreText;

    private void Start()
    {
        
        float survivalTime = PlayerPrefs.GetFloat("SurvivalTime", 0);
        int totalScore = PlayerPrefs.GetInt("TotalScore", 0);

       
        int minutes = Mathf.FloorToInt(survivalTime / 60F);
        int seconds = Mathf.FloorToInt(survivalTime % 60F);

       
        survivalTimeText.text = $"Temps de survie : {minutes:00}:{seconds:00}";
        totalScoreText.text = $"Score total : {totalScore}";
    }
}
