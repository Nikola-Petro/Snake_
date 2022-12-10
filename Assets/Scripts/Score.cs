using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text score;
    int scoreAmount = 0000;

  
    
    // Start is called before the first frame update
    void Start()
    {
        
        score.text = "Score: " + scoreAmount.ToString();
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
