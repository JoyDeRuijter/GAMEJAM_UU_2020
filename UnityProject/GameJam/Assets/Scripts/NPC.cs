using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    //Will handle interaction and random movement
    //Collision will be done elsewhere (and for all objects with collision)

    public DialogueController dialogue;
    
    public Entity entity;
    public Character character;
    public Tile npcTile;

    public Player player;
    
    public int roamRange;

    public int NPC_ID;

    int moveTimer;

    void Start()
    {
        dialogue = FindObjectOfType<DialogueController>();
        
        character = this.GetComponent<Character>();
        entity = GetComponent<Entity>();
        npcTile = GetComponent<Tile>();

        player = FindObjectOfType<Player>();

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
        
        if (player.interactTarget == "npc" && player.isInteracting)
        {
            if (player.interactPosition.X == this.entity.currentPosition.X && player.interactPosition.Y == this.entity.currentPosition.Y)
            {
                Interacted(NPC_ID);
            }
            
        }
    }

    public void Interacted(int id)                    //    TODO:    Make them face the player when interacted with!!
    {
        this.character.Direction = player.character.Direction + 2;
            if (this.character.Direction >= 4) //If the player looks up (dir=2), the npc will look down ((npc.dir=4)-4 = 0). 
                this.character.Direction -= 4;
            
        moveTimer = Random.Range(600, 1200);
        
        dialogue.NPC(id);
        
        /*
        switch (id)                        //not useful at the moment, but perhaps later when NPCs have more functionality than just being talked to.
       {
           case 0:
               Debug.Log("Uh-oh, something went wrong.");
               break;
           case 1:
               //Debug.Log("Well met, traveler! I'm number 1!");
               dialogue.NPC(id);
               break;
           case 2:
               //Debug.Log("Well met, traveler! I'm second-in-command!");
               dialogue.NPC(id); 
               break;
           case 3: 
               //Debug.Log("Well met, traveler! Third's the charm!");
               dialogue.NPC(id);
               break;
           default: 
               break;
       }
       */
    }

    void RandomMovement()
    {
        //    TODO: Roamrange is kapot gegaan bij merge; even naar kijken!!
        
        if (character.isMoving == false)
        {
            int caseDirection = Random.Range(0,3);        // Provides random movement for the NPC      
            
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
