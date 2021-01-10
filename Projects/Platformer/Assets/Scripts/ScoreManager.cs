using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;  //Handles the Text Mesh Pro that will count how many stars have been collected by the player


public class ScoreManager : MonoBehaviour
{
    
    public static ScoreManager instance;
    public TextMeshProUGUI text;
    int score;
    
    
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void ChangeScore(int starValue)
    {
        score += starValue;
        text.text = "X " + score.ToString();
    }
    
}
