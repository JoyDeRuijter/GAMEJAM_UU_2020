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
    public Character character;                    //    Making it public will allow the NPC script to use this to determine the player's direction, and adjust their own direction accordingly.
    NPC npc;

    public Tile.Position interactPosition;                //This could go to the character script instead, but NPCs currently have no use for this, thus it remains here.
    public string interactTarget;
    public bool isInteracting;
    
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
        else if (coolDownTimer <= 0)
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
        coolDown = 0.2;
        if (!character.isMoving)
        {
            if (Input.GetKey(KeyCode.S) && coolDownTimer == 0)
            {
                //character.isMoving = true;
                character.Move(0);
                coolDownTimer = coolDown;
            }
            if (Input.GetKey(KeyCode.W) && coolDownTimer == 0)
            {
                //character.isMoving = true;
                character.Move(2);
                coolDownTimer = coolDown;
            }
            if (Input.GetKey(KeyCode.A) && coolDownTimer == 0)
            {
                //character.isMoving = true;
                character.Move(1);
                coolDownTimer = coolDown;
            }
            if (Input.GetKey(KeyCode.D) && coolDownTimer == 0)
            {
                //character.isMoving = true;
                character.Move(3);
                coolDownTimer = coolDown;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
            isInteracting = true;
        else
            isInteracting = false;
    }
}
