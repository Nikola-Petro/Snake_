using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
   public BoxCollider2D grid;

    public GameObject snakeBooty;

    private void Start()
    {
        Vector2 startSpawnPoint = new Vector2(16, 0.0f);

    }
    void RandomSpawn()
    {
        Bounds bound = grid.bounds;

        float xDir = Random.Range(bound.min.x, bound.max.x);
        float yDir = Random.Range(bound.min.y, bound.max.y);

        

        this.transform.position = new Vector2(xDir, yDir);
    }
        
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {   
            RandomSpawn();
        }
        else if(this.transform.position == snakeBooty.transform.position)
        {
            RandomSpawn();
        }
    }
}