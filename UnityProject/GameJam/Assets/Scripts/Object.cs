using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    //Objects will be the same as NPCs, only they will not move and cannot always be interacted with.
    //Object IDs will make it possible to bind the correct 'dialogue', as well as (maybe?) sprite/animation to the object.
    
    public Tile.Position startPosition;
    public Tile.Position currentPosition;
    
    //public Tile objectTile;
    
    public int StartX;
    public int StartY;

    public int OBJ_ID;

    Tile tile;
    Grid grid;
   
    void Start()
    {
        tile = this.GetComponent<Tile>();
        grid = FindObjectOfType<Grid>();
        
        startPosition = new Tile.Position(StartX, StartY);
        currentPosition = startPosition;

        Generate();
    }

    void Generate()
    {
        //tile.IdTile(currentPosition.X, currentPosition.Y, 4);
    }

    void Update()
    {
        if(OBJ_ID==0)
            this.transform.position = new Vector3(this.currentPosition.X + 0.5F, this.currentPosition.Y + 0.5F, this.currentPosition.Y);
        else if(OBJ_ID==1)
            this.transform.position = new Vector3(this.currentPosition.X + 1.1F, this.currentPosition.Y + 0.5F, this.currentPosition.Y);
        
        tile.IdTile(currentPosition.X, currentPosition.Y, 4);
    }

    public void Interacted()
    {
        Debug.Log("This object doesn't appear to be very useful.");
    }
    
}
