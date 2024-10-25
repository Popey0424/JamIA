using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class CollisionEffects : MonoBehaviour
{
    public PlayerStats playerStats;
    public Score Score;

    [Header("AudioSources")]
    public AudioSource PlantHit;
    public AudioSource WallHit;
    public AudioSource HealingCollision;
    public AudioSource ScoreExplosion;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hole"))
        {
            if (playerStats.isInvicible)
            {

                Score.AddScore(50);
            }
            else
            {
                PlantHit.Play();
                Debug.Log("Hit par le Hole");
                playerStats.TakeDamage();
                playerStats.currentLives = 0;
                playerStats.GameOver();
            }
        }
        else if (other.CompareTag("Wall"))
        {
            if (playerStats.isInvicible)
            {
                WallHit.Play();
                Score.AddScore(50);
            }
            else
            {
                WallHit.Play();
                Debug.Log("Hit par le Wall");
                StartCoroutine(BlinkPlayer());
                playerStats.TakeDamage();
            }
        }
        else if (other.CompareTag("DestructibleWall"))
        {
            Score.AddScore(200);
        }
        else if (other.CompareTag("HealKit"))
        {
            if(playerStats.currentLives < playerStats.maxLives)
            {
                HealingCollision.Play();
                playerStats.Heal();
            }
            else
            {
                HealingCollision.Play();
                Score.AddScore(100);
            }
            Destroy(other.gameObject);

        }
        else if (other.CompareTag("Shield"))
        {
            playerStats.ActivateShield();
            
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Score"))
        {
            ScoreExplosion.Play();
            Score.AddScore(500);
            Destroy(other.gameObject);
        }
        
    }

    private IEnumerator BlinkPlayer()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        for (int i = 0; i < 5; i++)
        {
            renderer.enabled = !renderer.enabled;
            yield return new WaitForSeconds(0.2f);
        }

        renderer.enabled = true;
    }
}
    