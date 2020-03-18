using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TinderScore : MonoBehaviour
{
    public Text scoreText;
    public int score;
    Swiping swiping;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score;   
    }

    // Update is called once per frame
    void Update()
    { 
        scoreText.text = "Score: " + score;
    }
}
