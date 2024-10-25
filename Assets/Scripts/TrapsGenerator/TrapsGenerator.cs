using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsGenerator : MonoBehaviour
{
    public GameObject[] traps;  
    public Transform player;  
    public float spawnInterval = 2f;  
    public float spawnDistance = 10f;  

    private float[] lanes = { -4f, -2f, 0f, 2f, 4f }; 
    private float timeSinceLastSpawn = 0f; 

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        
        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnTrap();
            timeSinceLastSpawn = 0f; 
        }
    }

    void SpawnTrap()
    {
      
        int randomLaneIndex = Random.Range(0, lanes.Length);
        float lanePosition = lanes[randomLaneIndex];


        int randomTrapIndex = Random.Range(0, traps.Length);
        GameObject selectedTrap = traps[randomTrapIndex];


        Vector3 spawnPosition = new Vector3(lanePosition, player.position.y + spawnDistance, 0);


        Instantiate(selectedTrap, spawnPosition, Quaternion.identity);
    }
}
