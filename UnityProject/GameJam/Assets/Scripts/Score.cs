using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text text = null;
    Swiping swiping;

    // Start is called before the first frame update
    void Start()
    {
        text.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        ScoreCounter();
        text.text = "Score: " + swiping.score;
    }

    int ScoreCounter()
    {
        int currentScore = swiping.score;
        return currentScore;
    }
}
