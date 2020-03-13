using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    //Will handle interaction and random movement
    //Collision will be done elsewhere (and for all objects with collision)

    public Character character;
    public Entity entity;
    public Tile npcTile;
    
    public int roamRange;

    public int NPC_ID;

    int moveTimer;

    void Start()
    {
        character = this.GetComponent<Character>();
        entity = GetComponent<Entity>();
        npcTile = GetComponent<Tile>();

        Generate();
    }

    void Generate()
    {
        moveTimer = Random.Range(300,600);
    }

    void Update()
    {
        moveTimer--;
        if (moveTimer == 0)
        {
            RandomMovement();
            moveTimer = Random.Range(300,600);
        }
        
        npcTile.IdTile(entity.currentPosition.X, entity.currentPosition.Y, 2);
    }

    public void Interacted()
    {
        Debug.Log("Well met, traveler!");
    }

    void RandomMovement()
    {
        //TO DO:    Add a range for the NPCs to roam in;    Add alternative movement, in case the random direction is occupied/invalid
        if (character.isMoving == false)
        {
            int caseDirection = Random.Range(0,3);        // Provides random movement for the NPC      

            character.isMoving = true;
            
            
            switch (caseDirection)
            {
                case 0:        //Down
                    if (entity.currentPosition.Y + (roamRange - 1) >= entity.StartY)        //If the NPC is about to exit their roaming area, do NOT move
                        character.Move(0);                                                    //<Expand on this with the targetPosition later..>
                    else
                        RandomMovement();            //Maybe change their direction if they can't move somewhere instead.. or randomize it between both
                    break;
                case 1:        //Left
                    if (entity.currentPosition.X + (roamRange - 1) >= entity.StartX)
                        character.Move(1);
                    else
                        RandomMovement();
                    break;
                case 2:        //Up
                    if (entity.currentPosition.Y - (roamRange - 1) <= entity.StartY)
                        character.Move(2);
                    else
                        RandomMovement();
                    break;
                case 3:        //Right
                    if (entity.currentPosition.X - (roamRange - 1) <= entity.StartY)
                        character.Move(3);
                    else
                        RandomMovement();
                    break;
                default:
                    break;
            }
        }
    }
}
