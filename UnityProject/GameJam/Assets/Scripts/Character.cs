using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    //gaat de methodes voor movement bevatten; deze kunnen in een later NPC script voor random-movement aangeroepen worden, en kunnen bij de 'handle-input' van 't Player script aangeroepen worden
    
    Tile tile;
    Grid grid;
    private Entity entity;
    
    public bool isMoving = false;                   // The player may not move again while it is still moving
    public int Direction;                           // The direction the character is facing.    Will later be used to choose the right sprite, to reflect this.

    public void Start()
    {
        tile = this.GetComponent<Tile>();                // Each character has their own tile, with their own position. Therefor, tile must be a component
        grid = FindObjectOfType<Grid>();                // Grid is independant from the rest, but it's values and methods are still used
        entity = GetComponent<Entity>();
        
        Generate();
    }

    void Generate()
    {
        entity.startPosition = new Tile.Position(entity.StartX, entity.StartY);
        entity.currentPosition = entity.startPosition;
        entity.lastPosition = entity.startPosition;
        entity.targetPosition = entity.startPosition;
    }
    
    void Update()
    {
        this.transform.position = new Vector3(this.entity.currentPosition.X + 0.5F, this.entity.currentPosition.Y + 0.5F, this.entity.currentPosition.Y);
        
        tile.IdTile(entity.currentPosition.X, entity.currentPosition.Y, 4);
    }
    
    public void Move(int dir)
    {
        entity.lastPosition = entity.currentPosition;

        switch (dir)
        {
            case 0:
                entity.targetPosition = new Tile.Position(entity.currentPosition.X, entity.currentPosition.Y - 1);
                break;
            case 1:
                entity.targetPosition = new Tile.Position(entity.currentPosition.X - 1, entity.currentPosition.Y);
                break;
            case 2:
                entity.targetPosition = new Tile.Position(entity.currentPosition.X, entity.currentPosition.Y + 1);
                break;
            case 3:
                entity.targetPosition = new Tile.Position(entity.currentPosition.X + 1, entity.currentPosition.Y);
                break;
            default:
                break;
        }

        if (entity.targetPosition.isValid(grid))
            entity.currentPosition = entity.targetPosition;
            
        grid.ClearTile(entity.lastPosition.X, entity.lastPosition.Y);
        
        isMoving = false;
        Direction = dir;
    }
}
