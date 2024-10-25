using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsGenerator : MonoBehaviour
{
    public GameObject[] traps;  
    public GameObject[] Bonus;
    public Transform player;
    public float SpawnBonusInterval = 5f;
    public float spawnTrapInterval = 2f;  
    public float spawnDistance = 10f;  

    public float[] lanes = { -4f, -2f, 0f, 2f, 4f }; 
    private float timeSinceLastTrapSpawn = 0f; 
    private float timeSinceLastBonusSpawn = 0f; 

    void Update()
    {
        timeSinceLastTrapSpawn += Time.deltaTime;
        timeSinceLastBonusSpawn += Time.deltaTime;

        
        if (timeSinceLastTrapSpawn >= spawnTrapInterval)
        {
            SpawnTrap();
            timeSinceLastTrapSpawn = 0f; 
        }
        if(timeSinceLastBonusSpawn >= SpawnBonusInterval)
        {
            SpawnBonus();
            timeSinceLastBonusSpawn = 0f;
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
    void SpawnBonus()
    {

        int randomLaneIndex = Random.Range(0, lanes.Length);
        float lanePosition = lanes[randomLaneIndex];


        int randomBonusIndex = Random.Range(0, Bonus.Length);
        GameObject selectedBonus = Bonus[randomBonusIndex];


        Vector3 spawnPosition = new Vector3(lanePosition, player.position.y + spawnDistance, 0);


        Instantiate(selectedBonus, spawnPosition, Quaternion.identity);
    }
}
