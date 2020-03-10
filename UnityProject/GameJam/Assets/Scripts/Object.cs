using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    //Collision will be done elsewhere (and for all objects with collision)
    //Objects will be the same as NPCs, only they will not move and cannot always be interacted with.
    //Object IDs will make it possible to bind the correct 'dialogue', as well as (maybe?) sprite/animation to the object.
    
    public Tile objectTile;

    public int OBJ_ID;

   
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Interacted()
    {
        Debug.Log("This object doesn't appear to be very useful.");
    }
    
}
