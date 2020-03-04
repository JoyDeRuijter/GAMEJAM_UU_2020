using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    //gaat de methodes voor movement bevatten; deze kunnen in een later NPC script voor random-movement aangeroepen worden, en kunnen bij de 'handle-input' van 't Player script aangeroepen worden
    Vector2 position, targetedPosition;

    public bool isMoving = false;
    public int Direction;

    Tile tile;
    Grid grid;

    public void Start()
    {
        Generate();
    }

    public void Generate()
    {
        tile = this.GetComponent<Tile>();
        grid = FindObjectOfType<Grid>();
    }

    void Update()
    {
        this.transform.position = new Vector3(tile.PosX, tile.PosY + 0.5F);        //In tetris bewogen we de tetromino ook niet steeds in de grid. We veranderen steeds te vector, en om vervolgens de collision te checken gebruiken we die vector    
    }


    public void MoveDown()
    {
        if(tile.PosY > 0)
            tile.PosY--;
        isMoving = false;
        Direction = 0;
    }
    public void MoveUp()
    {   if(tile.PosY + 1 < Grid.gridHeight)
            tile.PosY++;
        isMoving = false;
        Direction = 1;
    }
    public void MoveLeft()
    {
        if(tile.PosX > 0)
            tile.PosX--;
        isMoving = false;
        Direction = 2;
    }
    public void MoveRight()
    {
        if(tile.PosX + 1 < Grid.gridWidth)
            tile.PosX++;
        isMoving = false;
        Direction = 3;
    }
}
