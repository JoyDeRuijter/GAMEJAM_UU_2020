using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    //gaat de methodes voor movement bevatten; deze kunnen in een later NPC script voor random-movement aangeroepen worden, en kunnen bij de 'handle-input' van 't Player script aangeroepen worden
    Vector2 position, targetedPosition;

    public bool isMoving = false;
    public int Direction;

    Tile tile;

    public void Start()
    {
        Generate();
    }

    public void Generate()
    {
        tile = this.GetComponent<Tile>();
    }

    void Update()
    {
        this.transform.position = new Vector3(tile.PosX, tile.PosY + 0.5F);        //In tetris bewogen we de tetromino ook niet steeds in de grid. We veranderen steeds te vector, en om vervolgens de collision te checken gebruiken we die vector    
    }


    public void MoveDown()
    {
        tile.PosY--;
        isMoving = false;
        Direction = 0;
    }
    public void MoveUp()
    {   
        isMoving = false;
        tile.PosY++;
        Direction = 1;
    }
    public void MoveLeft()
    {
        isMoving = false;
        tile.PosX--;
        Direction = 2;
    }
    public void MoveRight()
    {
        isMoving = false;
        tile.PosX++;
        Direction = 3;
    }
}
