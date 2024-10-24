using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsGenerator : MonoBehaviour
{
    public GameObject[] traps;  
    public Transform player;  
    public float spawnInterval = 2f;  
    public float spawnDistance = 10f;  

    private float[] lanes = { -2f, -1f, 0f, 1f, 2f };  // Les 5 positions (axes) possibles pour les pi�ges
    private float timeSinceLastSpawn = 0f;  // Timer pour contr�ler le d�lai de spawn

    void Update()
    {
        // Incr�menter le temps �coul� depuis la derni�re g�n�ration de pi�ge
        timeSinceLastSpawn += Time.deltaTime;

        // Si le d�lai d'attente est d�pass�, g�n�rer un nouveau pi�ge
        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnTrap();
            timeSinceLastSpawn = 0f;  // R�initialiser le timer
        }
    }

    void SpawnTrap()
    {
        // Choisir al�atoirement une voie parmi les 5 axes (positions)
        int randomLaneIndex = Random.Range(0, lanes.Length);
        float lanePosition = lanes[randomLaneIndex];

        // Choisir un pi�ge al�atoire parmi ceux disponibles
        int randomTrapIndex = Random.Range(0, traps.Length);
        GameObject selectedTrap = traps[randomTrapIndex];

        // Positionner le pi�ge devant le joueur, sur la voie choisie
        Vector3 spawnPosition = new Vector3(lanePosition, player.position.y + spawnDistance, 0);

        // Instancier le pi�ge � la position calcul�e
        Instantiate(selectedTrap, spawnPosition, Quaternion.identity);
    }
}
