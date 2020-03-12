using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    // Deze class behandelt alles wat in zowel character als object nodig is; Zo voorkomen we code duplication.
    // Onder entities valt alles binnen de overworld, behalve de tiles (dus karakters, objecten zoals bomen, maar ook gebouwen)
    
    public Tile.Position startPosition;
    public Tile.Position currentPosition;
    public Tile.Position lastPosition;
    public Tile.Position targetPosition;
    
    public int StartX;
    public int StartY;
    
    Tile tile;
    Grid grid;
    
    void Start()
    {
        tile = this.GetComponent<Tile>();
        grid = FindObjectOfType<Grid>();
    }

    void Update()
    {
        /*this.transform.position = new Vector3(this.currentPosition.X + 0.5F, this.currentPosition.Y + 0.5F, this.currentPosition.Y);
        
        tile.IdTile(currentPosition.X, currentPosition.Y, 4);*/
    }
}
