using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    //gaat de methodes voor movement bevatten; deze kunnen in een later NPC script voor random-movement aangeroepen worden, en kunnen bij de 'handle-input' van 't Player script aangeroepen worden

    //Positions    (of type Tile.Position)
    public Tile.Position lastPosition;
    public Tile.Position currentPosition;
    public Tile.Position targetPosition;            //must refer to THEIR OWN tile, otherwise NullReferenceException for ALL.

    Tile tile;
    Grid grid;
    
    public bool isMoving = false;                   // The player may not move again while it is still moving
    public int Direction;                           // The direction the character is facing.    Will later be used to choose the right sprite, to reflect this.

    public void Start()
    {
        tile = this.GetComponent<Tile>();                // Each character has their own tile, with their own position. Therefor, tile must be a component
        grid = FindObjectOfType<Grid>();                // Grid is independant from the rest, but it's values and methods are still used
        
        Generate();
    }

    public void Generate()
    {
        //lastPosition = tile.Position;
        //currentPosition = tile.Position;
        //targetPosition = null;                    //starts as null
    }

    void Update()
    {
        this.transform.position = new Vector3(this.currentPosition.X, this.currentPosition.Y + 0.5F);    // "ToWorldPosition"; ACTUAL position of characters is manipulated based on the position of their tile within the grid
    }


    public void MoveDown()
    {
        lastPosition = currentPosition;                // lastPosition becomes the currentPosition before the currentPosition is changed
        targetPosition.Y = currentPosition.Y - 1;                     // targetPosition changes based on the currentPosition, so we can check whether its possible to move there
        if(targetPosition.isValid(grid))               // Is targetPosition possible?
            currentPosition = targetPosition;                       // If yes, the currentPosition becomes the targetPosition
        isMoving = false;                              //isMoving is set back to false, because the move has been completed.    Will later be moved elsewhere, when gradual movement has been implemented.
        Direction = 0;                                 // The direction of the character has been changed accordingly
    }                                                  //Same actions down below.
    public void MoveUp()
    {   
        lastPosition = currentPosition;
        targetPosition.Y = currentPosition.Y + 1;
        if(targetPosition.isValid(grid))
            currentPosition = targetPosition;
        isMoving = false;
        Direction = 1;
    }
    public void MoveLeft()
    {
        lastPosition = currentPosition;
        targetPosition.X = currentPosition.X - 1;
        if(targetPosition.isValid(grid))
            currentPosition = targetPosition;
        isMoving = false;
        Direction = 2;
    }
    public void MoveRight()
    {
        lastPosition = currentPosition;
        targetPosition.X = currentPosition.X + 1;
        if(targetPosition.isValid(grid))
            currentPosition = targetPosition;
        isMoving = false;
        Direction = 3;
    }
}
