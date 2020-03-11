using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    //This script will determine the size of a bulding and the location of its entrances, if any.
    //Size could be done using arrays, and that array could be used to write about collision to the main grid.
    
    int Building_ID;

    private Vector2 position;

    private Tile tile;
    private Object building;
    private Grid grid;
    
    void Start()
    {
        tile = this.GetComponent<Tile>();
        building = this.GetComponent<Object>();
        grid = FindObjectOfType<Grid>();

        Generate();
    }

    void Generate()
    {
        BuildingSize(Building_ID);
    }

    void Update()
    {
        
    }

    void BuildingSize(int ID)
    {
        switch (ID)
        {
            case 0:                        //House
                Build(4,1, ID);
                break;
            case 1:                        //Flat
                Build(7,5, ID);
                break;
            case 2:                        //Uni
                Build(20, 5, ID);
                break;
            default:
                break;
        }
    }

    void Build(int width, int height, int ID)
    {
        for(int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {                                                        //Writes the identity of wall-tiles to the main grid
                tile.IdTile(building.currentPosition.X + x, building.currentPosition.Y + y, 5);
            }
        }
        switch (ID)
        {
            case 0:
                tile.IdTile(building.currentPosition.X + 2, building.currentPosition.Y + 0, 6);
                break;
            case 1:
                tile.IdTile(building.currentPosition.X + 3, building.currentPosition.Y + 4, 6);
                break;
            case 2:
                tile.IdTile(building.currentPosition.X + 5, building.currentPosition.Y + 4, 6);
                break;
            default:
                break;
        }
        
    }
}
