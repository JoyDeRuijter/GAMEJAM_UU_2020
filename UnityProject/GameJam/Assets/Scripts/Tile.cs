using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    Grid grid;

    public int cellWidth = 32;                      //karakter springt steeds te ver uit t scherm. andere waarden misschien?
    public int cellHeight = 32;

    public int PosX;
    public int PosY;


    bool isMoving = false;

    void Start()
    {

    }

    void Update()
    {
        this.transform.position = new Vector2(cellWidth * PosX, cellHeight * PosY);        //In tetris bewogen we de tetromino ook niet steeds in de grid. We veranderen steeds te vector, en om vervolgens de collision te checken gebruiken we die vector    
        
        if (Input.GetKeyDown(KeyCode.DownArrow))                                //movement staat tijdelijk hier. Hij kan terug naar Player wanneer de nullreference gefikst is
        {
            isMoving = true;
            PosY++;
            Debug.Log("Test");
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            isMoving = true;
            PosY--;
            Debug.Log("Test");
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            isMoving = true;
            PosX--;
            Debug.Log("Test");
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            isMoving = true;
            PosX++;
            Debug.Log("Test");
        }
    }
}
