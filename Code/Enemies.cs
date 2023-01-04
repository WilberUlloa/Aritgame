using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public float speedEnemies = 4f;
    public Transform pyr;

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,
        new Vector2(pyr.position.x, transform.position.y), speedEnemies*Time.deltaTime);
    }
}
