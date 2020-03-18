using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLose : MonoBehaviour
{
    public Goal goal;
    public Score score;
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
        if (timer.timeUp == true && score.score >= goal.goal)
            hasWon = true;
        else if (timer.timeUp == true && score.score < goal.goal)
            hasLost = true;
        else
            isPlaying = true;

        if (isPlaying)
        {
            GameObject.Find("Good").transform.localScale = new Vector3(0, 0, 0);
            GameObject.Find("Wrong").transform.localScale = new Vector3(0, 0, 0);
        }
        else if (hasWon)
            GameObject.Find("Good").transform.localScale = new Vector3(5, 5, 1);
        else if (hasLost)
            GameObject.Find("Wrong").transform.localScale = new Vector3(5, 5, 1);

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
        GameObject.Find("Arrows").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("Left").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("Right").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("Phone").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("GoalText").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("TimerText").transform.localScale = new Vector3(0, 0, 0);
    }
}
