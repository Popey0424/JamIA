using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private GameObject heartPrefab;
    private List<GameObject> hearts = new List<GameObject>();

    private void Start()
    {
        UpdateHearts();
    }

    public void UpdateHearts()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        hearts.Clear();
        for (int i = 0; i < playerStats.currentLives; i++)
        {
              GameObject newHeart = Instantiate(heartPrefab, transform);
              hearts.Add(newHeart);
        }
    }
}
