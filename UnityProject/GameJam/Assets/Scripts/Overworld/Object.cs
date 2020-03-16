using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    //Objects will be the same as NPCs, only they will not move and cannot always be interacted with.
    //Object IDs will make it possible to bind the correct 'dialogue', as well as (maybe?) sprite/animation to the object.
    
    public int OBJ_ID;
    
    private Tile tile;
    private Entity entity;

    private bool isGenerated;
   
    void Start()
    {
        tile = GetComponent<Tile>();
        entity = GetComponent<Entity>();

        Generate();
    }

    void Generate()
    {
        entity.startPosition = new Tile.Position(entity.StartX, entity.StartY);
        entity.currentPosition = entity.startPosition;
        
        this.transform.position = new Vector3(this.entity.currentPosition.X + 0.5F, this.entity.currentPosition.Y + 0.5F, this.entity.currentPosition.Y);

        isGenerated = false;
    }

    void Update()
    {
       //this.transform.position = new Vector3(this.entity.currentPosition.X + 0.5F, this.entity.currentPosition.Y + 0.5F, this.entity.currentPosition.Y);
       if(isGenerated==false)
       {
           isGenerated = true;
           tile.IdTile(this.entity.currentPosition.X, this.entity.currentPosition.Y, 4);            //Het liefst doen we deze in de Generate-methode, maar dat leidt tot een NullReference error.
       }
    }

    public void Interacted()
    {
        Debug.Log("This object doesn't appear to be very useful.");
    }
    
}
