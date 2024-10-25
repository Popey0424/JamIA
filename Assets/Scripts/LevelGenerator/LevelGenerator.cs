using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] levelPrefabs;
    [SerializeField] private Transform player;
    [SerializeField] private float spawnDistance = 10f;


    private float spawnY = 0f;

    private void Update()
    {
        if(player.position.y + spawnDistance > spawnY)
        {
            SpawnBlock();
        }
    }

    private void SpawnBlock()
    {
        int randomIndex = Random.Range(0, levelPrefabs.Length);
        GameObject newBlock = Instantiate(levelPrefabs[randomIndex], new Vector3(0, spawnY, 0), Quaternion.identity);
        spawnY += newBlock.GetComponent<Renderer>().bounds.size.y;
    }
}
