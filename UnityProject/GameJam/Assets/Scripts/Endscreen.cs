using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endscreen : MonoBehaviour
{
    public Goal goal;
    public ScoreScript score;
    public Timer timer;
    public bool hasWon;
    public bool hasLost;
    public bool isPlaying;

    // Start is called before the first frame update
    void Start()
    {
        isPlaying = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.timeUp == true && score.scoreValue >= goal.goal)
        {
            hasWon = true;
            isPlaying = false;
        }
        else if (timer.timeUp == true && score.scoreValue < goal.goal)
        {
            hasLost = true;
            isPlaying = false;
        }
        else
            isPlaying = true;

        /*
        if (isPlaying)
        {
            GameObject lost = GameObject.Find("Lost");
            lost.SetActive(false);
            GameObject won = GameObject.Find("Won");
            won.SetActive(false);
        }
        else if (hasWon)
        {
            GameObject won = GameObject.Find("Won");
            won.SetActive(true);
        }
        else if (hasLost)
        {
            GameObject lost = GameObject.Find("Lost");
            lost.SetActive(true);
        }
        */
        WinOrLose();
    }


    void WinOrLose()
    {
        if (hasWon == true)
        {
            isPlaying = false;
            HideGame();
        }
        else if (hasLost == true)
        {
            isPlaying = false;
            HideGame();
        }
        else if (isPlaying == true)
            return;
    }

    void HideGame()
    {
      /*  GameObject.Find("Arrows").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("Left").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("Right").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("Phone").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("GoalText").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("TimerText").transform.localScale = new Vector3(0, 0, 0);
        */
    }
}
