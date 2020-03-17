﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Swiping : MonoBehaviour
{
    private Score score;
    //public int score = 0;
    public Arrows arrow;
    // Start is called before the first frame update
    void Start()
    {
        score = FindObjectOfType<Score>();
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (arrow.isLeft == true)
            {
                arrow.isLeft = false;
                score.score += 10;
                arrow.GenerateNumber();
            }
            else
            {
                //show mistake
                arrow.isLeft = false;
                score.score -= 5;
                arrow.GenerateNumber();
            }

        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (arrow.isRight == true)
            {
                arrow.isRight = false;
                score.score += 10;
                arrow.GenerateNumber();
            }
            else
            {
                // show mistake
                arrow.isRight = false;
                score.score -= 5;
                arrow.GenerateNumber();
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }
}
