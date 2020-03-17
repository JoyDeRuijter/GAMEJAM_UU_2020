using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLose : MonoBehaviour
{
    Goal goal;
    Score score;
    Timer timer;
    public bool hasWon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer.timeUp == true && score.score >= goal.goal)
        {
            hasWon = true;
        }
        else if(timer.timeUp == true && score.score < goal.goal)
        {
            hasWon = false;
        }
    }

    void WinScreen()
    {

    }

    void LoseScreen()
    {

    }

    void WinOrLose()
    {
        if (hasWon == true)
        {
            WinScreen();
        }
        else if (hasWon == false)
        {
            LoseScreen();
        }
    }
}
