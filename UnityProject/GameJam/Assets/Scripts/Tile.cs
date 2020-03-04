using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int PosX;
    public int PosY;

    private Grid grid;
    
    public int tileID;
    string TileID;

    void Start()
    {
        grid = FindObjectOfType<Grid>();
        
        
    }

    
    
    void Update()
    {
        identifyTile();                //expensive. Could this be moved elsewhere? Perhaps after movement, and/or during initialization
    }

    void identifyTile()
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
        grid.IdentifyTile(PosX, PosY, TileID);
    }
    
    
    
}
