using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2Int snakePosition;
    private Vector2Int direction = Vector2Int.right;
    private float moveTimer = 1f;
    private float currentTime;


    private void Awake()
    {
        snakePosition.Set(5, 5);
        currentTime = moveTimer;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            direction = Vector2Int.up;
        } else if (Input.GetKeyDown(KeyCode.S))
        {
            direction = Vector2Int.down;
        } else if (Input.GetKeyDown(KeyCode.A))
        {
            direction = Vector2Int.left;
        } else if (Input.GetKeyDown(KeyCode.D))
        {
            direction = Vector2Int.right;
        }



        transform.position = new Vector3(snakePosition.x + direction.x, snakePosition.y + direction.y, 0);
    }

    private void FixedUpdate()
    {

        

    }
}
