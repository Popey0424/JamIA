using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int maxLives = 3;
    [SerializeField] private int currentLives;
    [SerializeField] private bool isInvicible = false;
    [SerializeField] private float invicibilityDuration = 15f;



    private void Start()
    {
        currentLives = maxLives;
    }

    public void TakeDamage()
    {
        if (!isInvicible)
        {
            currentLives--;
            if(currentLives <= 0)
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


    private void GameOver()
    {
        Debug.Log("GameOver");
    }
}
