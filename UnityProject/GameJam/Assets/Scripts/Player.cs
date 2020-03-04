using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;

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
        
        tile.tileID = 2;
    }

    void Update()
    {
        HandleInput();
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
                    if (tile.PosX == npc.npcTile.PosX && tile.PosY - 1 == npc.npcTile.PosY)
                        npc.Interacted();
                    break;
                case 1:
                    if (tile.PosX == npc.npcTile.PosX && tile.PosY + 1 == npc.npcTile.PosY)
                        npc.Interacted();
                    break;
                case 2:
                    if (tile.PosX - 1 == npc.npcTile.PosX && tile.PosY == npc.npcTile.PosY)
                        npc.Interacted();
                    break;
                case 3:
                    if (tile.PosX + 1 == npc.npcTile.PosX && tile.PosY == npc.npcTile.PosY)
                        npc.Interacted();
                    break;
                default:
                    break;
            }
        }
    }
}
