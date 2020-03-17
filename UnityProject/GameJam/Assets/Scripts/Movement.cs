using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Animations;
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
    private float maxwidth = 51f;
    private float minwidth = -51f;
    //game points
    public int points = 0;
    //animation
    public Animator anim;

    public bool WalkingRight = true;
    public bool WalkingLeft = false;
    
    
    
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
                changeY();
                anim.SetBool("WalkingRight", false);
                movementSpeed = movementSpeedRandomizer();
                state = "left";
                break;
            case "invisible left":
                changeY();
                anim.SetBool("WalkingRight", true);
                movementSpeed = movementSpeedRandomizer();
                state = "right";
                break;
          
        }
      
    }
    

    
    //Generating a random number that can be used for creating random speed
    static float movementSpeedRandomizer()
    {
        float min = 0.8f;
        float max = 1f;
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

