using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    public PlayerStats playerStats;


    private float timeElapsed;
    private bool isTimerRunning;


    private void Start()
    {
        timeElapsed = 0f;
        isTimerRunning = true;
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            timeElapsed += Time.deltaTime;
            UpdateTimerDisplay();
        }
        if (playerStats.currentLives <= 0 && isTimerRunning)
        {
            Stoptimer();
        }


    }
    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeElapsed / 60F);
        int seconds = Mathf.FloorToInt(timeElapsed % 60F);


        timerText.text = $"{minutes:00}:{seconds:00}";  

    }

    public float GetTimeElapsed()
    {
        return timeElapsed;
    }

    private void Stoptimer()
    {
        isTimerRunning = false;

    }
}
