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
        get { return 55; }
    }

    public static int gridHeight
    {
        get { return 40; }
    }

    Vector2 position; //positie van de grid zelf

    // Start is called before the first frame update
    void Start()
    {
        position = Vector2.zero;
        grid = new string[gridWidth, gridHeight];                    // An empty grid is created, with the correct dimensions
    }

    public void WriteTile(int x, int y, string id)             //moet aangeroepen worden op t moment dat iets zich wil verplaatsen. De 'targetposition' zijn dan de meegegeven x en y waarden die de methode nodig heeft
    {
        grid[x, y] = id;                                    // The provided string-ID is written into the correct location in the grid.
        
    }

    public void ClearTile(int x, int y)
    {
        grid[x, y] = null;
    }

    public bool isOccupied(int x, int y)
    {
        if (grid[x, y] == null)            //if the requested tile is an empty floor tile, it is 'unoccupied'
            return false;
        else
            return true;
    }

    public string OfType(int x, int y)                //Method name W.I.P.
    {
        if (x >= 0 && x < gridWidth && y >= 0 && y < gridHeight)            //    The if-statement ensures no OutOfBounds exception occurs.
            return grid[x, y];
        else
            return null;
    }

// Update is called once per frame
    void Update()
    {

    }
}
