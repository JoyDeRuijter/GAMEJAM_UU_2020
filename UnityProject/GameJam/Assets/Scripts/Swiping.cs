using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swiping : MonoBehaviour
{
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            //if (visablearrow = leftarrow)
                //delete arrowclone
                // up score
            //else if (visablearrow = rightarrow)
                //show error sign
                //delete arrowclone
                // keep score or maybe even lose points
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            //if (visablearrow = rightarrow)
            //delete arrowclone
            // up score
            //else if (visablearrow = leftarrow)
            //show error sign
            //delete arrowclone
            // keep score or maybe even lose points
        }
    }

    public int CalculateScore()
    {
        // keep track of score
        return score;
    }

    public void WriteScore()
    {
        // write score on the screen using CalculateScore(); and int score
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }
}
