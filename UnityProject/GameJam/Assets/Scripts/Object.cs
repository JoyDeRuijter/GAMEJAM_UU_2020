using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    //Objects will be the same as NPCs, only they will not move and cannot always be interacted with.
    //Object IDs will make it possible to bind the correct 'dialogue', as well as (maybe?) sprite/animation to the object.
    
    public DialogueController dialogue;
    
    public int OBJ_ID;

    private Player player;
    private Tile tile;
    private Entity entity;

    private bool isGenerated;
    private bool interactedWith;
   
    void Start()
    {
        dialogue = FindObjectOfType<DialogueController>();

        player = FindObjectOfType<Player>();
        
        tile = GetComponent<Tile>();
        entity = GetComponent<Entity>();

        Generate();
    }

    void Generate()
    {
        entity.startPosition = new Tile.Position(entity.StartX, entity.StartY);
        entity.currentPosition = entity.startPosition;
        
        this.transform.position = new Vector3(this.entity.currentPosition.X + 0.5F, this.entity.currentPosition.Y + 0.5F, this.entity.currentPosition.Y);

        isGenerated = false;
    }

    void Update()
    {
       //this.transform.position = new Vector3(this.entity.currentPosition.X + 0.5F, this.entity.currentPosition.Y + 0.5F, this.entity.currentPosition.Y);
       if(isGenerated==false)
       {
           isGenerated = true;
           tile.IdTile(this.entity.currentPosition.X, this.entity.currentPosition.Y, 3);            //Het liefst doen we deze in de Generate-methode, maar dat leidt tot een NullReference error.
       }
       
       if (player.interactTarget == "obj")    //    If player is facing an object..
       {
           if (player.interactPosition.X == this.entity.currentPosition.X &&
               player.interactPosition.Y == this.entity.currentPosition.Y)    //    And that object is this.object...
           {
               Debug.Log("Object's interactionhandler is called");
               InteractionHandler(OBJ_ID);            //    start handling interaction
           }
       }
    }

    public void InteractionHandler(int id)
    {
        if (player.isInteracting)
        {
            //DINGEN DIE HIJ EEN KEER DOET TIJDENS INTERACTION
            if (!interactedWith)
                EngageInteraction(OBJ_ID);        
            
            //DINGEN DIE HIJ CONTINU DOET TIJDENS INTERACTION
        }
        else if (!player.isInteracting && interactedWith)
            EndInteraction();
    }

    void EngageInteraction(int objID)
    {
        interactedWith = true;
        
        Debug.Log("Object interaction works");

        if (objID != 0)
        {
            EventController.ObjectFound(OBJ_ID);
            FindObjectOfType<DialogueController>().Object(objID);
        }
        else
        {
            player.isInteracting = false;
        }

        if (GetComponent<QuestGiver>() != null)
            GetComponent<QuestGiver>().GiveQuest();
    }

    void EndInteraction()
    {
        Debug.Log("Ending interaction");
        interactedWith = false;
        //Close window here
        Debug.Log("Closing interaction window");
        FindObjectOfType<DialogueController>().clearLine();
    }

}
