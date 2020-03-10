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

        public Position(int x, int y)            //Can add a 'depth' parameter here
        {
            this.X = X;
            this.Y = Y;
        }
        public bool isValid(Grid grid)
        {
            
            if (grid.isOccupied(X, Y) == false && X >= 0 && Y >= 0 && X <= Grid.gridWidth && Y <= Grid.gridHeight)
                return true;
            else
                return false;
        }
    }
    
    void Update()
    {
        IdTile();                //expensive. Could this be moved elsewhere? Perhaps after movement, and/or during initialization
    }

    void IdTile()
    {
        switch (tileID)
        {
            case 0:            //when the id is '0' (thus, a ground tile), don't give it a TileID.
                break;
            case 1:
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
        //grid.IdentifyTile(Position.Position().X, Position.Position.Y, TileID);
    }
    
    
    
}
