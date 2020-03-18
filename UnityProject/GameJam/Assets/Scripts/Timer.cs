using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timer;
    float timeLeft = 60;
    public bool timeUp;
    

    // Start is called before the first frame update
    void Start()
    {
        timer.text = "Time left: " + (int)timeLeft + " seconds";
    }

    // Update is called once per frame
    void Update()
    {
        timer.text = "Time left: " + (int)timeLeft + " seconds";

        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            timeLeft = 0;
            timeUp = true;
        }
    }
}
