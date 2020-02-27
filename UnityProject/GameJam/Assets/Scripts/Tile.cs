using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    Grid grid;

    public int cellWidth = 32;
    public int cellHeight = 32;

    Vector2 Position;

    public int PosX;
    public int PosY;


    void Start()
    {

    }

    void Update()
    {
        Position = new Vector2(cellWidth * PosX, cellHeight * PosY);        //In tetris bewogen we de tetromino ook niet steeds in de grid. We veranderen steeds te vector, en om vervolgens de collision te checken gebruiken we die vector
    }
}
