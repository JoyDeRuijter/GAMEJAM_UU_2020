using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    //gaat de methodes voor movement bevatten; deze kunnen in een later NPC script voor random-movement aangeroepen worden, en kunnen bij de 'handle-input' van 't Player script aangeroepen worden

    //Positions    (of type Tile.Position)
    public Tile.Position startPosition;
    public Tile.Position lastPosition;
    public Tile.Position currentPosition;
    public Tile.Position targetPosition;            //must refer to THEIR OWN tile, otherwise NullReferenceException for ALL.

    public int StartX;
    public int StartY;
    
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
    }

    void Update()
    {
        this.transform.position = new Vector3(this.currentPosition.X + 0.5F, this.currentPosition.Y + 0.5F, this.currentPosition.Y);    // "ToWorldPosition"; ACTUAL position of characters is manipulated based on the position of their tile within the grid
    }


    public void MoveDown()
    {
        lastPosition = currentPosition;                // lastPosition becomes the currentPosition before the currentPosition is changed
        
        targetPosition = new Tile.Position(currentPosition.X, currentPosition.Y - 1);                   // targetPosition changes based on the currentPosition, so we can check whether its possible to move there
        
        if(targetPosition.isValid(grid))               // Is targetPosition possible?
            currentPosition = targetPosition;                       // If yes, the currentPosition becomes the targetPosition
        
        grid.ClearTile(lastPosition.X, lastPosition.Y);
        
        isMoving = false;                              //isMoving is set back to false, because the move has been completed.    Will later be moved elsewhere, when gradual movement has been implemented.
        Direction = 0;                                 // The direction of the character has been changed accordingly
    }                                                  //Same actions down below.
    
    public void MoveUp()
    {   
        lastPosition = currentPosition;
        
        Tile.Position newPosition = new Tile.Position(currentPosition.X, currentPosition.Y + 1);
        
        targetPosition = newPosition;
        
        if(targetPosition.isValid(grid))
            currentPosition = targetPosition;
        
        grid.ClearTile(lastPosition.X, lastPosition.Y);
        
        isMoving = false;
        Direction = 1;
    }
    
    public void MoveLeft()
    {
        lastPosition = currentPosition;

        targetPosition = new Tile.Position(currentPosition.X - 1, currentPosition.Y);
        
        if (targetPosition.isValid(grid))
            currentPosition = targetPosition;
        
        grid.ClearTile(lastPosition.X, lastPosition.Y);

        isMoving = false;
        Direction = 2;
    }
    
    public void MoveRight()
    {
        lastPosition = currentPosition;
        
        targetPosition = new Tile.Position(currentPosition.X + 1, currentPosition.Y);
        
        if (targetPosition.isValid(grid))
            currentPosition = targetPosition;
        
        grid.ClearTile(lastPosition.X, lastPosition.Y);
        
        isMoving = false;
        Direction = 3;
    }

   /* public void Move(int dir)
    {
        lastPosition = currentPosition;

        switch (dir)
        {
            case 0:
                targetPosition = new Tile.Position(currentPosition.X, currentPosition.Y - 1);
                break;
            case 1:
                targetPosition = new Tile.Position(currentPosition.X + 1, currentPosition.Y + 1);
                break;
            case 2:
                targetPosition = new Tile.Position(currentPosition.X -1, currentPosition.Y);
                break;
            case 3:
                targetPosition = new Tile.Position(currentPosition.X + 1, currentPosition.Y);
                break;
            default:
                break;
        }

        Debug.Log(targetPosition.X + ", " + targetPosition.Y);
        
        if (targetPosition.isValid(grid))
            currentPosition = targetPosition;
        
        Debug.Log(currentPosition.X + ", " + currentPosition.Y);
        Debug.Log(targetPosition.isValid(grid));
        
        isMoving = false;
        Direction = 3;
    }*/
}
