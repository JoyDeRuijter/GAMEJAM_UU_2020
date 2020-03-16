using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    //gaat de methodes voor movement bevatten; deze kunnen in een later NPC script voor random-movement aangeroepen worden, en kunnen bij de 'handle-input' van 't Player script aangeroepen worden

    public Animator animator;
    
    Tile tile;
    Grid grid;
    private Entity entity;
    
    public bool isMoving = false;                   // The player may not move again while it is still moving
    public int Direction;                           // The direction the character is facing.    Will later be used to choose the right sprite, to reflect this.

    private float movingSpeed;
    private Vector3 movingTowards;
    
    public void Start()
    {
        tile = this.GetComponent<Tile>();                // Each character has their own tile, with their own position. Therefor, tile must be a component
        grid = FindObjectOfType<Grid>();                // Grid is independant from the rest, but it's values and methods are still used
        entity = GetComponent<Entity>();
        
        movingSpeed = 0.08F;
        
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
        animator.SetInteger("Direction", Direction);

        if (!this.isMoving)
        {
            this.transform.position = new Vector3(this.entity.currentPosition.X + 0.5F,
                this.entity.currentPosition.Y, this.entity.currentPosition.Y);
            animator.SetBool("Moving", false);
        }
        
        //TODO: Clean this up a little.. AFTER merge with NPC branch!!
        else if (this.isMoving)
        {
            animator.SetBool("Moving", true);
         
            this.transform.position = movingTowards;        //    The apparent position of the sprite will be updated with the movingPosition each tick.

            if (Direction == 0)
            {
                movingTowards.y -= movingSpeed;                    //    While the character is moving in a direction, the movingTowards will gradually grow or shrink.
                if (movingTowards.y <= this.entity.currentPosition.Y)       //    if the movingTowards position has reached it's targetted position, movement will stop.
                {
                    isMoving = false;
                }
            }
            else if (Direction == 2)
            {
                movingTowards.x -= movingSpeed;
                if (movingTowards.x <= this.entity.currentPosition.X + 0.5F)
                {
                    isMoving = false;
                }
            }
            else if (Direction == 1)
            {
                movingTowards.y += movingSpeed;
                if (movingTowards.y >= this.entity.currentPosition.Y)
                {
                    isMoving = false;
                }
            }
            else if (Direction == 3)
            {
                movingTowards.x += movingSpeed;
                
                if (movingTowards.x >= this.entity.currentPosition.X + 0.5F)
                {
                    isMoving = false;
                }
            }
        }

        tile.IdTile(entity.currentPosition.X, entity.currentPosition.Y, 4);
        
    }
    
    public void Move(int dir)
    {
        isMoving = true;
        
        movingTowards = transform.position;
        
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
        
        //isMoving = false;
        Direction = dir;
    }
}
