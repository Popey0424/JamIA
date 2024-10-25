using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerStats : MonoBehaviour
{
    public int maxLives = 3;
    public int currentLives = 3;
    public bool isInvicible = false;
    [SerializeField] private float invicibilityDuration = 15f;
    public HealthUI healthUI;
    public CharacterController characterController;
    [SerializeField] private Image imageFade;

    public Sprite normalSprite;
    public Sprite ShieldedSprite;
    private SpriteRenderer spriteRenderer;


    private void Start()
    {
        imageFade.gameObject.SetActive(false);
        currentLives = maxLives;
        healthUI.UpdateHearts();
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        spriteRenderer.sprite = normalSprite;
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
        spriteRenderer.sprite = ShieldedSprite;
        Invoke(nameof(DeactivateShield), invicibilityDuration);
        
    }


    private void DeactivateShield()
    {
        isInvicible = false;
        spriteRenderer.sprite = normalSprite;
    }


    public void GameOver()
    {
        imageFade.gameObject.SetActive(true);
        characterController.moveSpeed = 0;
        imageFade.DOFade(1, 0.8f).OnComplete(LoadGameOver);
        PlayerPrefs.SetFloat("SurvivalTime", FindObjectOfType<Timer>().GetTimeElapsed());
        PlayerPrefs.SetInt("TotalScore", FindObjectOfType<Score>().GetScore());
        Debug.Log("GameOver");
    }

    private void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
