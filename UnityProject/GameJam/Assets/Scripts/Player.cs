using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
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
        tile = this.GetComponent<Tile>();
    }
     
    // Update is called once per frame
    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.DownArrow))                                //movement staat tijdelijk hier. Hij kan terug naar Player wanneer de nullreference gefikst is
        {
            isMoving = true;
            tile.PosY--;
            Debug.Log("Test");
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            isMoving = true;
            tile.PosY++;
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
}
