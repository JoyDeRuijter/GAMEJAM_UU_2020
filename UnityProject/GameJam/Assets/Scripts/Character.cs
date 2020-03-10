using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    //gaat de methodes voor movement bevatten; deze kunnen in een later NPC script voor random-movement aangeroepen worden, en kunnen bij de 'handle-input' van 't Player script aangeroepen worden
    public Tile.Position lastPosition, currentPosition;
    public Tile.Position targetPosition = null;

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
        this.transform.position = new Vector3(currentPosition.X, currentPosition.Y + 0.5F);        //In tetris bewogen we de tetromino ook niet steeds in de grid. We veranderen steeds te vector, en om vervolgens de collision te checken gebruiken we die vector    
    }


    public void MoveDown()
    {
        lastPosition = currentPosition;
        targetPosition.Y -= 1;
        if(targetPosition.isValid(grid))
            currentPosition.Y--;
        isMoving = false;
        Direction = 0;
    }
    public void MoveUp()
    {   
        lastPosition = currentPosition;
        if(targetPosition.isValid(grid))
            currentPosition.Y++;
        isMoving = false;
        Direction = 1;
    }
    public void MoveLeft()
    {
        lastPosition = currentPosition;
        if(targetPosition.isValid(grid))
            currentPosition.X--;
        isMoving = false;
        Direction = 2;
    }
    public void MoveRight()
    {
        lastPosition = currentPosition;
        if(targetPosition.isValid(grid))
            currentPosition.X++;
        isMoving = false;
        Direction = 3;
    }
}
