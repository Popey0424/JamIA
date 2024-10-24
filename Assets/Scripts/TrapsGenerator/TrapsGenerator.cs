using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsGenerator : MonoBehaviour
{
    public GameObject[] traps;  
    public Transform player;  
    public float spawnInterval = 2f;  
    public float spawnDistance = 10f;  

    private float[] lanes = { -2f, -1f, 0f, 1f, 2f };  // Les 5 positions (axes) possibles pour les pièges
    private float timeSinceLastSpawn = 0f;  // Timer pour contrôler le délai de spawn

    void Update()
    {
        // Incrémenter le temps écoulé depuis la dernière génération de piège
        timeSinceLastSpawn += Time.deltaTime;

        // Si le délai d'attente est dépassé, générer un nouveau piège
        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnTrap();
            timeSinceLastSpawn = 0f;  // Réinitialiser le timer
        }
    }

    void SpawnTrap()
    {
        // Choisir aléatoirement une voie parmi les 5 axes (positions)
        int randomLaneIndex = Random.Range(0, lanes.Length);
        float lanePosition = lanes[randomLaneIndex];

        // Choisir un piège aléatoire parmi ceux disponibles
        int randomTrapIndex = Random.Range(0, traps.Length);
        GameObject selectedTrap = traps[randomTrapIndex];

        // Positionner le piège devant le joueur, sur la voie choisie
        Vector3 spawnPosition = new Vector3(lanePosition, player.position.y + spawnDistance, 0);

        // Instancier le piège à la position calculée
        Instantiate(selectedTrap, spawnPosition, Quaternion.identity);
    }
}
