using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    //Will handle interaction and random movement
    //Collision will be done elsewhere (and for all objects with collision)

    public Character npc;
    public Tile npcTile;
    
    int StartX;
    int StartY;
    public int roamRange;

    public int NPC_ID;

    int moveTimer;
   
    void Start()
    {
        npc = this.GetComponent<Character>();
        npcTile = GetComponent<Tile>();

        StartX = npc.currentPosition.X;
        StartY = npc.currentPosition.Y;
        
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
    }

    public void Interacted()
    {
        Debug.Log("Well met, traveler!");
    }

    void RandomMovement()
    {
        //TO DO:    Add a range for the NPCs to roam in;    Add alternative movement, in case the random direction is occupied/invalid
        if (npc.isMoving == false)
        {
            int caseDirection = Random.Range(0,3);        //0=down, 1=up, 2=left, 3=right

            npc.isMoving = true;
            switch (caseDirection)
            {
                case 0:
                    if (npc.currentPosition.Y + (roamRange - 1) >= StartY)
                        npc.MoveDown();
                    else
                        RandomMovement();            //Maybe change their direction if they can't move somewhere instead.. or randomize it between both
                    break;
                case 1:
                    if (npc.currentPosition.Y - (roamRange - 1) <= StartY)
                        npc.MoveUp();
                    else
                        RandomMovement();
                    break;
                case 2:
                    if (npc.currentPosition.X + (roamRange - 1) >= StartX)
                        npc.MoveLeft();
                    else
                        RandomMovement();
                    break;
                case 3:
                    if (npc.currentPosition.X - (roamRange - 1) <= StartY)
                        npc.MoveRight();
                    else
                        RandomMovement();
                    break;
                default:
                    break;
            }
        }
    }
}
