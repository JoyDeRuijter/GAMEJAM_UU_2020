using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    //Will handle interaction and random movement
    //Collision will be done elsewhere (and for all objects with collision)

    Character npc;
    public Tile npcTile;

    int moveTimer;
   
    void Start()
    {
        npc = this.GetComponent<Character>();
        npcTile = GetComponent<Tile>();
        moveTimer = 1200;
    }

    void Update()
    {
        moveTimer--;
        if (moveTimer == 0)
        {
            RandomMovement();
            moveTimer = 1200;
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
            int caseDirection = Random.Range(0,3);

            npc.isMoving = true;
            switch (caseDirection)
            {
                case 0:
                    npc.MoveDown();
                    break;
                case 1:
                    npc.MoveUp();
                    break;
                case 2:
                    npc.MoveLeft();
                    break;
                case 3:
                    npc.MoveRight();
                    break;
                default:
                    npc.isMoving = false;
                    break;
            }
        }
    }
}
