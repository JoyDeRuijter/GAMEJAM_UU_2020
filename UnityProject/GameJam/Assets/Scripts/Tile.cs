using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private Grid _grid;
    
    public int tileID;
    string TileID;
    
    void Start()
    {
        _grid = FindObjectOfType<Grid>();
    }

    public class Position
    {
        public int X;
        public int Y;

        public Position(int x, int y)                // Could add a 'depth' parameter here
        {
            this.X = x;
            this.Y = y;
        }
        public bool isValid(Grid grid)                // Will only be called by targetPosition, to check the viability of the requested movement
        {
            /*if (!(X >= 0 && Y >= 0 && X < Grid.gridWidth && Y < Grid.gridHeight)) // If the targetPosition falls outside the grid.. 
                return false;                                                     // ...ALWAYS invalid.
            if (grid.isOccupied(X, Y) == false)                                  //If the targetPosition does not collide with anything...
                    return true;                                                 //Valid!
            else
                    return false;*/
            if (X >= 0 && Y >= 0 && X < Grid.gridWidth && Y < Grid.gridHeight && grid.isOccupied(X, Y) == false)
                    return true;
            else
                return false;

        }
    }
    
    void Update()
    {
        //IdTile();                //expensive. Could this be moved elsewhere? Perhaps after movement, and/or during initialization
    }

    public void IdTile(int x, int y, int tileID)                //Based on the given number of a Tile, a string-ID is given to the corresponding location within the grid.
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
        _grid.IdentifyTile(x, y, TileID);       //The IdentifyTile method is called to bind the ID to the correct location in the grid.     
    }
    
    
    
}
