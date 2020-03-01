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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public int RandomNumber(int min, int max)
    {
        System.Random random = new System.Random();
        return random.Next(min, max);
    }

    public void CreateArrows()
    {
        //iets met een timer of na ieder nummer wordt Number = 3 zodat dan even allebei de pijlen op false gaan
        Number = RandomNumber(0, 2);
        if (Number == 0)
        {
            isLeft = true;
            isRight = false;
        }
        else if (Number == 1)
        {
            isLeft = false;
            isRight = true;
        }
        else if (Number == 2)
        {
            isLeft = true;
            isRight = true;
        }
        else if (Number == 3)
        {
            isLeft = false;
            isRight = false;
        }
        if (isLeft == true)
        {
            GameObject arrowClone = Instantiate(arrow, new Vector2((float)-2, (float)-0.5), Quaternion.identity);
            //idk hoe ik hier in verder moet atm
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
