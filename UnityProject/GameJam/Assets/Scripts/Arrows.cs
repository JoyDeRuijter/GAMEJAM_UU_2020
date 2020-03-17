using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Arrows : MonoBehaviour
{
    public GameObject arrow;
    public int Number;
    public bool isRight;
    public bool isLeft;

    public int RandomNumber(int min, int max)
    {
        System.Random random = new System.Random();
        return random.Next(min, max);
    }

    public void GenerateNumber()
    {
        Number = RandomNumber(0, 2);
    }

    public void CreateArrows()
    {
        switch (Number)
        {
            case 0:
                isLeft = true;
                isRight = false;
                break;
            case 1:
                isLeft = false;
                isRight = true;
                break;
            case 2:
                isLeft = true;
                isRight = true;
                break;
            default:
                isLeft = false;
                isRight = false;
                break;
        }
    }

    public void ShowArrows()
    {
        if (isLeft == true)
        {
            GameObject.Find("Left").transform.localScale = new Vector3(3, 3, 1);
        }
        else
        {
            GameObject.Find("Left").transform.localScale = new Vector3(0, 0, 0);
        }

        if (isRight == true)
        {
            GameObject.Find("Right").transform.localScale = new Vector3(3, 3, 1);
        }
        else
        {
            GameObject.Find("Right").transform.localScale = new Vector3(0, 0, 0);
        }
    }
    // Update is called once per frame
    void Update()
    {
        CreateArrows();
        ShowArrows();
    }
}
