using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Swiping : MonoBehaviour
{
    private Score score;
    public Arrows arrow;
    public WinLose winLose;
    public bool isHighlightedL;
    public bool isHighlightedR;

    // Start is called before the first frame update
    void Start()
    {
        score = FindObjectOfType<Score>();
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.A) && winLose.isPlaying == true)
        {
            if (arrow.isLeft == true)
            {
                arrow.isLeft = false;
                score.score += 1;
                arrow.GenerateNumber();
            }
            else
            {
                arrow.isLeft = false;
                score.score -= 5;
                arrow.GenerateNumber();
            }

        }
        if (Input.GetKeyDown(KeyCode.D) && winLose.isPlaying == true)
        {
            if (arrow.isRight == true)
            {
                arrow.isRight = false;
                score.score += 1;
                arrow.GenerateNumber();
            }
            else
            {
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
/*
    void HighlightLeft()
    {
        StartCoroutine(ShowAndHide(GameObject.Find("HighlightedLeft"), 0.5f)); // 0,5 seconds
    }
    void HighlightRight()
    {
        StartCoroutine(ShowAndHide(GameObject.Find("HighlightedRight"), 0.5f)); // 0,5 seconds
    }

    IEnumerator ShowAndHide(GameObject go, float delay)
    {
        go.SetActive(true);
        yield return new WaitForSeconds(delay);
        go.SetActive(false);
    }
*/
}
