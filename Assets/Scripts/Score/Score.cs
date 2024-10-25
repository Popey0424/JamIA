using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    public CharacterController characterController;

    private float score = 0f;
    private float pointsPerSecond = 10f;
    private float speedMultiplier = 1f;

    private void Update()
    {
        speedMultiplier = characterController.moveSpeed;
        score += pointsPerSecond * speedMultiplier * Time.deltaTime;
        scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();

    }
}
