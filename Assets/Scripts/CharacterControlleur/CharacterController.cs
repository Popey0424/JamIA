using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float initialSpeed = 5f;  
    [SerializeField] private float speedIncreaseFactor = 0.5f;  
    [SerializeField] private float speedIncreaseInterval = 15f;  

    public float moveSpeed;
    public float[] lanes = { -4f, -2f, 0f, 2f, 4f };  
    [SerializeField] private int currentLane = 2; 
    private float timeSinceLastIncrease = 0f;  

    private void Start()
    {
        moveSpeed = initialSpeed;  
    }

    private void Update()
    {
        Debug.Log(moveSpeed);
        timeSinceLastIncrease += Time.deltaTime;

       
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);


        if (timeSinceLastIncrease >= speedIncreaseInterval)
        {
            IncreaseSpeed();  
            timeSinceLastIncrease = 0f;  
        }

 
        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentLane > 0)
        {
            currentLane--;
            MoveToLane();
        }

    
        if (Input.GetKeyDown(KeyCode.RightArrow) && currentLane < lanes.Length - 1)
        {
            currentLane++;
            MoveToLane();
        }
    }

    private void MoveToLane()
    {
   
        Vector3 targetPosition = new Vector3(lanes[currentLane], transform.position.y, transform.position.z);
        transform.position = targetPosition;
    }

    private void IncreaseSpeed()
    {
   
        Debug.Log("Vitesse augmentée");
        moveSpeed *= (1 + speedIncreaseFactor);
    }
}