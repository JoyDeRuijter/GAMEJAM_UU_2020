using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro.EditorUtilities;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Rigidbody2D rb;

    Character character;
    Tile tile;
    NPC npc;

    public void Start()
    {
        Generate();
    }

    public void Generate()
    {
        character = this.GetComponent<Character>();
        tile = GetComponent<Tile>();
        npc = FindObjectOfType<NPC>();
    
        
        character.startPosition = new Tile.Position(character.StartX, character.StartY);
        character.currentPosition = character.startPosition;
        character.lastPosition = character.startPosition;
        character.targetPosition = character.startPosition;
        
        tile.tileID = 2;
    }

    void Update()
    {
        HandleInput();
        tile.IdTile(character.currentPosition.X, character.currentPosition.Y, 1);
    }

    void HandleInput()
    {
        if (character.isMoving == false)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                character.isMoving = true;
                character.MoveDown();
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                character.isMoving = true;
                character.MoveUp();
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                character.isMoving = true;
                character.MoveLeft();
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                character.isMoving = true;
                character.MoveRight();
            }
        }


        //TO DO:    Add interaction for all interactable objects (like trash bins, etc.), make a new script for this.       
        //          Expand on it, so each object may have different results when interacted with
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Interacting..");
            //Nog een beetje vies, en werkt momenteel niet voor iedere NPC apart
            switch (character.Direction)
            {
                case 0:
                    if (character.currentPosition.X == npc.npc.currentPosition.X && character.currentPosition.Y - 1 == npc.npc.currentPosition.Y)
                        npc.Interacted();
                    break;
                case 1:
                    if (character.currentPosition.X == npc.npc.currentPosition.X && character.currentPosition.Y + 1 == npc.npc.currentPosition.Y)
                        npc.Interacted();
                    break;
                case 2:
                    if (character.currentPosition.X - 1 == npc.npc.currentPosition.X && character.currentPosition.Y == npc.npc.currentPosition.Y)
                        npc.Interacted();
                    break;
                case 3:
                    if (character.currentPosition.X + 1 == npc.npc.currentPosition.X && character.currentPosition.Y == npc.npc.currentPosition.Y)
                        npc.Interacted();
                    break;
                default:
                    break;
            }
        }
    }
}
