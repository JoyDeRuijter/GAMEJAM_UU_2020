using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    //Will handle interaction and random movement
    //Collision will be done elsewhere (and for all objects with collision)

    //public DialogueController dialogue;
    
    public Entity entity;
    public Character character;
    public Tile npcTile;

    public QuestGiver questGiver;
    
    public Player player;
    
    public int roamRange;

    public int NPC_ID;

    private int moveTimer;
    private bool isTalking;

    void Start()
    {
        //dialogue = FindObjectOfType<DialogueController>();

        if (GetComponent<QuestGiver>() != null)
        {
            questGiver = GetComponent<QuestGiver>();
        }
        
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
        //Debug.Log(isTalking);
        moveTimer--;
        if (moveTimer == 0)
        {
            RandomMovement();
            moveTimer = Random.Range(300, 600);
        }

        /*if (!isTalking)
        {
            FindObjectOfType<DialogueController>().clearLine();
        }*/


        npcTile.IdTile(entity.currentPosition.X, entity.currentPosition.Y, 2);

        if (player.interactTarget == "npc")    //    If player is facing an npc..
        {
            if (player.interactPosition.X == this.entity.currentPosition.X &&
                player.interactPosition.Y == this.entity.currentPosition.Y)    //    And that npc is this.npc...
            {
                InteractionHandler(NPC_ID);            //    start handling interaction
            }
        }
    }

    public void InteractionHandler(int npcID)                    //    TODO:    Make them face the player when interacted with!!
    {
        //EventController.NpcInteracted(NPC_ID);
        //FindObjectOfType<DialogueController>().NPC(npcID);

        if (player.isInteracting)
        {
            //DINGEN DIE HIJ EEN KEER DOET TIJDENS INTERACTION
            if (!isTalking)
                EngageConversation(npcID);        
            
            //DINGEN DIE HIJ CONTINU DOET TIJDENS INTERACTION
            moveTimer = Random.Range(600, 1200);
            this.character.Direction = player.character.Direction + 2;
            if (this.character.Direction >= 4)         //If the player looks up (dir=2), the npc will look down ((npc.dir=4)-4 = 0). 
                this.character.Direction -= 4;
        }
        if (!player.isInteracting && isTalking)
            EndConversation();
        
    }

    void EngageConversation(int npcID)
    {
        isTalking = true;

        if (npcID != 0)
        {
            EventController.NpcInteracted(NPC_ID);
            if (GetComponent<QuestGiver>() != null && !GetComponent<QuestGiver>().questGiven)
            {
                FindObjectOfType<DialogueController>().Quest(GetComponent<QuestGiver>().questName, 1);
                GetComponent<QuestGiver>().GiveQuest();
            }
            else if (GetComponent<QuestGiver>() == null || GetComponent<QuestGiver>().questGiven)
                FindObjectOfType<DialogueController>().NPC(npcID);

            
        }
        else
        {
            player.isInteracting = false;
        }

        

    }

    public void EndConversation()
    {
        isTalking = false;
        //    Close window here
        FindObjectOfType<DialogueController>().clearLine();
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










