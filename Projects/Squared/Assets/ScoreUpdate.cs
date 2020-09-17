using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreUpdate : MonoBehaviour
{
    
    private Text score;
    private int scoreValue = 0;
    
    // Start is called before the first frame update
    void Start()
    {

        score = GetComponent <Text>();
        score.text = scoreValue.ToString();
    }

    public void AddToScore(int ScoreAddition)
    {
        scoreValue += ScoreAddition;
        score.text = scoreValue.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
