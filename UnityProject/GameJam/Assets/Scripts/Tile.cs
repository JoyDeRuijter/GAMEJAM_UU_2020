using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
   private Grid grid;
    
    public int tileID;
    string TileID;
    
    void Start()
    {
        grid = FindObjectOfType<Grid>();
    }

    public class Position
    {
        public int X;
        public int Y;

        public Position(int x, int y)                // Could add a 'depth' parameter here
        {
            this.X = X;
            this.Y = Y;
        }
        public bool isValid(Grid grid)                // Will only be called by targetPosition, to check the viability of the requested movement
        {
            if (grid.isOccupied(X, Y) == false &&    //If the targetPosition does not collide with anything...
            X >= 0 && Y >= 0 && X <= Grid.gridWidth && Y <= Grid.gridHeight)    // AND If the targetPosition does not fall outside the grid..
                return true;                                                    //...it is valid.
            else
                return false;
        }
    }
    
    void Update()
    {
        IdTile();                //expensive. Could this be moved elsewhere? Perhaps after movement, and/or during initialization
    }

    void IdTile()                //Based on the given number of a Tile, a string-ID is given to the corresponding location within the grid.
    {
        switch (tileID)
        {
            case 0:            //when the id is '0' (thus, a ground tile), don't give it a TileID.
                break;
            case 1:            //all other tiles provide collision, and thus are given a string-ID
                TileID = "player";
                break;
            case 2:
                TileID = "npc";
                break;
            case 4:
                TileID = "obj";
                break;
            case 5:
                TileID = "wall";
                break;
            case 6:
                TileID = "door";
                break;
            default:
                break;
        }
        //grid.IdentifyTile(Position.Position().X, Position.Position.Y, TileID);       //The IdentifyTile method is called to bind the ID to the correct location in the grid.     
    }
    
    
    
}
