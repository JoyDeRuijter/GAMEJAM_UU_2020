using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    //Collision will be done elsewhere (and for all objects with collision)

    
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
