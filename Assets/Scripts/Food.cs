using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private Bounds bound;

    private void Awake()
    {
        bound = new Bounds(new Vector3(0, 0), new Vector3(44, 84));

        randomPosition();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        randomPosition();
    }

    private void randomPosition()
    {
        transform.position = new Vector3((int)Random.Range(bound.min.x, bound.max.x), (int)Random.Range(bound.min.y, bound.max.y));
    }
}
