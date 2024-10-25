using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class PlayerStats : MonoBehaviour
{
    public int maxLives = 3;
    public int currentLives;
    public bool isInvicible = false;
    [SerializeField] private float invicibilityDuration = 15f;
    public HealthUI healthUI;
    public CharacterController characterController;
    [SerializeField] private Image imageFade;


    private void Start()
    {
        currentLives = maxLives;
        healthUI.UpdateHearts();
    }

    public void TakeDamage()
    {
        if (!isInvicible)
        {
            currentLives--;
            healthUI.UpdateHearts();
            if (currentLives <= 0)
            {
                GameOver();
            }
        }
    }

    public void Heal()
    {
        if(currentLives < maxLives)
        {
            currentLives++;
            healthUI.UpdateHearts();
        }
    }

    public void ActivateShield()
    {
        isInvicible = true;
        Invoke(nameof(DeactivateShield), invicibilityDuration);
    }

    private void DeactivateShield()
    {
        isInvicible = false;
    }


    public void GameOver()
    {
        characterController.moveSpeed = 0;


        Debug.Log("GameOver");
    }
}
