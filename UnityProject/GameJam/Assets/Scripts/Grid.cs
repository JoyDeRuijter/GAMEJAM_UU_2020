using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public static string[,] grid;
    //public static string[,] tiles;

    public static int gridWidth
    {
        get { return 9; }
    }

    public static int gridHeight
    {
        get { return 9; }
    }

    Vector2 position; //positie van de grid zelf

    // Start is called before the first frame update
    void Start()
    {
        position = Vector2.zero;
        grid = new string[gridWidth, gridHeight];
    }

    public void IdentifyTile(int x, int y, string id)             //moet aangeroepen worden op t moment dat iets zich wil verplaatsen. De 'targetposition' zijn dan de meegegeven x en y waarden die de methode nodig heeft
    {
        grid[x, y] = id;                
        
    }

    public bool isOccupied(int x, int y)
    {
        if (grid[x, y] == null)            //if the requested tile is an empty floor tile, it is 'unoccupied'
            return false;
        else
            return true;
    }

// Update is called once per frame
    void Update()
    {

    }
}
