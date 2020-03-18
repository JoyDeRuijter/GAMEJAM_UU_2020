using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class FriendsMovement : MonoBehaviour
{
    //position of the object
    Vector2  position;
    private Vector3 clickUser;
    
    private float movementSpeed;
    //default state is moving right
    //string state = "right";
    //camera view
    private float maxheight = 35f;
    private float minheight = -35f;
    //do not know why but these have to be private
    private float maxwidth = 60f;
    private float minwidth = -60f;
    //game points
    [FormerlySerializedAs("points")] public int ScoreValue = 0;
    //animation
    public Animator anim;

    public bool walkingRight;
    public bool movementReset;
    
    private int direction;

    Endscreen end;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
       

        Generate();
    }

    void Generate()
    {
            walkingRight ^= true;
            movementSpeed = movementSpeedRandomizer();
            position.y = positionYRandomizer();
    }
    
    // Update is called once per frame
    void Update()
    {
            transform.position = position;

            //direction = Random.Range(0, 1);

            if (position.x < (minwidth - 15) || position.x >= (maxwidth + 15))
            {
                Generate();
            }

            Move();
    }
    

    
    //Generating a random number that can be used for creating random speed
    static float movementSpeedRandomizer()
    {
        float min = 0.1f;
        float max = 0.6f;
        return Random.Range(min, max);
    }

    public float positionYRandomizer()
    {
        return Random.Range(minheight, maxheight);
    }

    void Move()
    {
            if (walkingRight)
            {
                anim.SetBool("WalkingRight", true);
                position.x += movementSpeed;
                //Debug.Log("moving right");
                //Debug.Log(position.x + " + " + movementSpeed + " = " + (position.x+movementSpeed));
            }
            else
            {
                anim.SetBool("WalkingRight", false);
                position.x -= movementSpeed;
                //Debug.Log("Moving left");
            }
    }
    
}

