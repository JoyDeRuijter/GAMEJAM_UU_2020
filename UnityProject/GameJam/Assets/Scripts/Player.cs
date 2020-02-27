using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Player player;
    Rigidbody2D rb;
    Vector2 position, targetedPosition;

    bool isMoving = false;

    Tile tile;

    // Start is called before the first frame update
    public void Start()
    {
        Generate();
    }

    public void Generate()
    {
        Tile tile = this.GetComponent<Tile>();
    }

    // Update is called once per frame
    /*void Update()
    {
        //if(isMoving == false)
        { 
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                isMoving = true;
                tile.PosX++;
                Debug.Log("Test");
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                isMoving = true;
                tile.PosX--;
                Debug.Log("Test");
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                isMoving = true;
                tile.PosX--;
                Debug.Log("Test");
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                isMoving = true;
                tile.PosX++;
                Debug.Log("Test");
            }
        }
    }*/
}
