using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Snake : MonoBehaviour
{
    public List<Transform> body = new List<Transform>();

    public Transform bodyParts;


    Vector2 move = Vector2.right;
 
    int lenght = 3;

    public string apple;

 
    public Text scoreDisplay;
    int scoreAmount = 0;

    private void Start()
    {
        Base();       
    }
        
    private void Update()
    {

        if(Input.GetKeyDown(KeyCode.W) && move != Vector2.down)
        {
            move = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.A) && move != Vector2.right)
        {
            move = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.S) && move != Vector2.up)
        {
            move = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.D) && move != Vector2.left)
        {
            move = Vector2.right;
        }

        
    }

    private void FixedUpdate()
    {
    
        for(int i = body.Count-1; i > 0; i--)
        {
            body[i].position = body[i - 1].position;
        }

        this.transform.position = new Vector3(Mathf.Round(this.transform.position.x) + move.x, Mathf.Round(this.transform.position.y) + move.y, 0.0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Food")
        {
            Grow();
        }
        else if(other.tag == "Obsticale")
        {
            GameOver();
        }
    }

    void Grow()
    {
        Transform bodyPartsCopy = Instantiate(this.bodyParts);
        bodyPartsCopy.position = body[body.Count - 1].position;

        body.Add(bodyPartsCopy);



        scoreAmount += 10;

        scoreDisplay.text = $"Score: {scoreAmount}";
        
    }

    void GameOver()
    {
        for(int i = 1; i < body.Count; i++)
        {
            Destroy(body[i].gameObject);
        } 
        body.Clear();
        Base();

        move = Vector2.right;
        this.transform.position = new Vector3(0.0f, 0.0f, 0.0f);

    }

    void Base()
    {

        
        body.Add(this.transform);
        for(int i = 0; i < lenght; i++)
        {
            Grow();
        }

        GameObject food = GameObject.Find(apple);

        food.transform.position = new Vector3(16f, 0.0f, 0.0f);
        scoreAmount = 0;
        scoreDisplay.text = scoreDisplay.text = $"Score: {scoreAmount}";
    }

 
}
    