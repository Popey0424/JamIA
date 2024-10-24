using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinityBackground : MonoBehaviour
{
    [SerializeField] private GameObject backgroundPrefab;
    [SerializeField] private Transform player;
    [SerializeField] private int numberOfBackgrounds = 3;
    [SerializeField] private float backgroundHeight = 10f;

    private GameObject[] Backgrounds;
    private float CameraHeight;

    private void Start()
    {
        CameraHeight = Camera.main.orthographicSize * 2.0f;

        Backgrounds = new GameObject[numberOfBackgrounds];
        for(int i = 0; i < Backgrounds.Length; i++)
        {
            Backgrounds[i] = Instantiate(backgroundPrefab, new Vector3(0, i * backgroundHeight, 0), Quaternion.identity );

        }
    }

    private void Update()
    {
        for (int i = 0; i < Backgrounds.Length; i++)
        {
             if(player.position.y - CameraHeight > Backgrounds[i].transform.position.y + backgroundHeight)
            {
                Vector3 newPos = Backgrounds[i].transform.position;
                newPos.y += backgroundHeight * numberOfBackgrounds; 
                Backgrounds[i].transform.position = newPos;
            }
        }
    }
}
