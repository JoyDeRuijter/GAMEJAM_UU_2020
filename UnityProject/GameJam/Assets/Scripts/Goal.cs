using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TinderGameGoal : MonoBehaviour
{
    public Text goalText;
    public int goal;

    // Start is called before the first frame update
    void Start()
    {
        goal = 300;
        goalText.text = "Goal: " + goal;
    }
}
