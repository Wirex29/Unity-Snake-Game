using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEnd;


public class Wall : MonoBehaviour
{
    private BoxCollider2D bColli;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
    }
}
