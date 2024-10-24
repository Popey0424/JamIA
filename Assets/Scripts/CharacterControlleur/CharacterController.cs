using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 5f;
    [SerializeField] private float speedIncreaseFactor = 0.01f;
    [SerializeField] private float maxSpeed = 20f;


    private float[] lanes = { -4f, -2f, 0, 2f, 4f };
    [SerializeField] private int currentLanes = 2;

    private void Update()
    {
        Debug.Log(moveSpeed);
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
        moveSpeed = Mathf.Min(maxSpeed, moveSpeed + speedIncreaseFactor);


        if(Input.GetKeyDown(KeyCode.LeftArrow) && currentLanes > 0)
        {
            currentLanes--;
            MoveToLane();
        }

        if(Input.GetKeyDown(KeyCode.RightArrow) && currentLanes < lanes.Length - 1)
        {
            currentLanes++;
            MoveToLane();
        }
        
    }

    private void MoveToLane()
    {
        Vector3 targetpostion = new Vector3(lanes[currentLanes], transform.position.y, 0);
        transform.position = targetpostion;
    }

    
}
