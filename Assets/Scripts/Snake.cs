using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2Int snakePosition;
    private Vector2Int direction;
    private float moveTimer;
    private float currentTime;


    private void Awake()
    {
        snakePosition.Set(5, 5);
        moveTimer = 1f;
        direction = Vector2Int.right;
        currentTime = moveTimer;
        Time.fixedDeltaTime = 1;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            direction = Vector2Int.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            direction = Vector2Int.down;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            direction = Vector2Int.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            direction = Vector2Int.right;
        }

        //currentTime += Time.deltaTime;
        //if (currentTime >= moveTimer)
        //{
        //    snakePosition += direction;
        //    currentTime -= moveTimer;
        //}

        //Debug.Log(Time.deltaTime);

        //snakePosition += direction;


    }

    private void FixedUpdate()
    {
        snakePosition += direction;
        transform.position = new Vector3(snakePosition.x, snakePosition.y);
    }
}
