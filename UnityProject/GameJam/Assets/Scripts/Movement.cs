using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Experimental.UIElements;
using Random = UnityEngine.Random;

public class Movement : MonoBehaviour
{
    //position of the object
    Vector3  position;
    private Vector3 clickUser;
    
    private float movementSpeed;
    //default state is moving right
    string state = "right";
    //camera view
    private float maxheight = 35f;
    private float minheight = -35f;
    //do not know why but these have to be private
    private float maxwidth = 71f;
    private float minwidth = -71f;
    //game points
    public int points = 0;
    //animator
    public Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        movementSpeed = movementSpeedRandomizer();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      
       // Debug.Log(points);
      
       switch (state)
        {
            case "right":
                moveRight();
                if (position.x >= (maxwidth+ 10))
                {
                    state = "invisible right";
                }
                break;
            case "left":
                moveLeft();
                if (position.x <= (minwidth - 10))
                {
                    state = "invisible left";
                }
                break;
            case "invisible right":
                anim.SetTrigger("OutOfViewRight");
                changeY();
                movementSpeed = movementSpeedRandomizer();
                state = "left";
                break;
            case "invisible left":
                anim.SetTrigger("OutOfViewLeft");
                changeY();
                movementSpeed = movementSpeedRandomizer();
                state = "right";
                break;
          
        }
      
    }
    

    
    //Generating a random number that can be used for creating random speed
    static float movementSpeedRandomizer()
    {
        float min = 0.8f;
        float max = 5f;
        return Random.Range(min, max);
    }

    public float positionYRandomizer()
    {
        
        return Random.Range(minheight, maxheight);

    }

    void moveRight()
    {
        
        //Debug.Log("i am going right");
        position.x += movementSpeed;
        transform.position = position;
        
    }

    void moveLeft()
    {
        //Debug.Log(" i am going left");
        position.x -= movementSpeed;
        transform.position = position;
    }

    void changeY()
    {
        position.y = positionYRandomizer();
        transform.position = position;
    }

    void OnMouseDown()
    {
        points += 1; 
        
    }
}

