using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro.EditorUtilities;
using UnityEngine;

public class Player : MonoBehaviour
{
    Grid grid;
    Tile tile;
    
    Entity entity;
    Character character;
    NPC npc;

    Tile.Position interactPosition;                //This could go to the character script instead, but NPCs currently have no use for this, thus it remains here.
    private string interactTarget;
    
    public double coolDownTimer;
    public double coolDown;
    
    
    public void Start()
    {
        grid = FindObjectOfType<Grid>();
        tile = GetComponent<Tile>();
        
        character = this.GetComponent<Character>();
        entity = GetComponent<Entity>();
        
        npc = FindObjectOfType<NPC>();
        
        
        Generate();
    }

    public void Generate()
    {
         
    }

    void Update()
    {
        if (coolDownTimer > 0)
            coolDownTimer -= Time.deltaTime;

        if (coolDownTimer < 0)
            coolDownTimer = 0;

        if(character.Direction == 0 || character.Direction == 2)
            interactPosition = new Tile.Position(entity.currentPosition.X, entity.currentPosition.Y - 1 + character.Direction);    //If the direction is down, the target will be below. If the direction is up, the target will be above
        else
            interactPosition = new Tile.Position(entity.currentPosition.X - 2 + character.Direction, entity.currentPosition.Y);    //If the direction is left, the target will be left. If the direction is right, the target will be right.
        interactTarget = grid.OfType(interactPosition.X, interactPosition.Y);
        
        HandleInput();
        tile.IdTile(entity.currentPosition.X, entity.currentPosition.Y, 1);
    }

    void HandleInput()
    {
        coolDown = 0.1;
        if (character.isMoving == false)
        {
            if (Input.GetKeyDown(KeyCode.S) && coolDownTimer == 0)
            {
                character.isMoving = true;
                character.Move(0);
            }
            if (Input.GetKeyDown(KeyCode.W) && coolDownTimer == 0)
            {
                character.isMoving = true;
                character.Move(2);
            }
            if (Input.GetKeyDown(KeyCode.A) && coolDownTimer == 0)
            {
                character.isMoving = true;
                character.Move(1);
            }
            if (Input.GetKeyDown(KeyCode.D) && coolDownTimer == 0)
            {
                character.isMoving = true;
                character.Move(3);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Interacting..");

            switch (interactTarget)
            {
                case "npc":
                    //    Ik wil nu weten WELKE NPC of WELK object er op de 'interactPosition' zit, zodat de juiste dialoog gevoerd kan worden
                    Debug.Log("..With an NPC");
                    break;
                case "obj":
                    Debug.Log("..With an object");
                    break;
                case "door":
                    Debug.Log("..With a door");
                    break;
                default:
                    break;
            }
            
            
            /*
            if (grid.OfType(interactPosition.X, interactPosition.Y) == "npc")
            {
                Debug.Log("..With an NPC");
            }
            else if (grid.OfType(interactPosition.X, interactPosition.Y) == "obj")
            {
                Debug.Log("..With an object");
            }
            else if (grid.OfType(interactPosition.X, interactPosition.Y) == "door")
            {
                Debug.Log("..With a door");
            }
            */
        }
    }
}
