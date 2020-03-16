using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Swiping : MonoBehaviour
{
    public int score = 0;
    public Arrows arrow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (arrow.isLeft == true)
            {
                arrow.isLeft = false;
                score += 10;
                arrow.GenerateNumber();
            }
            else
            {
                //show mistake
                arrow.isLeft = false;
                score -= 5;
                arrow.GenerateNumber();
            }

        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (arrow.isRight == true)
            {
                arrow.isRight = false;
                score += 10;
                arrow.GenerateNumber();
            }
            else
            {
                // show mistake
                arrow.isRight = false;
                score -= 5;
                arrow.GenerateNumber();
            }
        }
    }

    public int CalculateScore()
    {
        // keep track of score
        return score;
    }

    public void WriteScore()
    {
        Console.WriteLine("Score: " + score);
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        WriteScore();
    }
}
