using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text text;
    public int score;
    Swiping swiping;

    // Start is called before the first frame update
    void Start()
    {
        //score = 0;
        text.text = "Score: " + score;
        
    }

    // Update is called once per frame
    void Update()
    {
        //ScoreCounter();
        Debug.Log(score);
        text.text = "Score: " + score;
    }

    /*int ScoreCounter()
    {
        int currentScore = swiping.score;
        return currentScore;
    }*/
}
