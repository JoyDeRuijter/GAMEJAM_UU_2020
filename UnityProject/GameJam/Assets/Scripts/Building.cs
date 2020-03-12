using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    //This script will determine the size of a bulding and the location of its entrances, if any.
    //Size could be done using arrays, and that array could be used to write about collision to the main grid.
    
    public int Building_ID;

    private Vector2 position;

    private Tile tile;
    private Entity entity;
    
    private bool isGenerated;

    
    void Start()
    {
        entity = this.GetComponent<Entity>();
        tile = this.GetComponent<Tile>();
        
        Generate();
    }

    void Generate()
    { 
        entity.startPosition = new Tile.Position(entity.StartX, entity.StartY);
        entity.currentPosition = entity.startPosition;
        
        this.transform.position = new Vector3(this.entity.currentPosition.X + 2.1F, this.entity.currentPosition.Y + 0.5F, this.entity.currentPosition.Y);

        isGenerated = false;
    }

    void Update()
    {
        //this.transform.position = new Vector3(this.entity.currentPosition.X + 1.1F, this.entity.currentPosition.Y + 0.5F, this.entity.currentPosition.Y);
        if (isGenerated == false)
        {
            isGenerated = true;
            BuildingSize(Building_ID); //Het liefst doen we deze in de Generate-methode, maar dat leidt tot een NullReference error.
        }
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
                tile.IdTile(entity.currentPosition.X + x, entity.currentPosition.Y + y, 5);
            }
        }
        switch (ID)
        {
            case 0:
                tile.IdTile(entity.currentPosition.X + 2, entity.currentPosition.Y + 0, 6);
                break;
            case 1:
                tile.IdTile(entity.currentPosition.X + 3, entity.currentPosition.Y + 4, 6);
                break;
            case 2:
                tile.IdTile(entity.currentPosition.X + 5, entity.currentPosition.Y + 4, 6);
                break;
            default:
                break;
        }
        
    }
}
