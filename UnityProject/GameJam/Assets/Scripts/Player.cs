using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Player player;
    Rigidbody2D rb;
    Vector2 position, targetedPosition;

    bool ismoving = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ismoving == false)
        { 
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                ismoving = true;
                // player.position = ;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                ismoving = true;
                // player.position = ;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                ismoving = true;
                // player.position = ;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                ismoving = true;
                // player.position = ;
            }
        }
    }
}
