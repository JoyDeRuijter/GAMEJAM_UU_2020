using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public static string[,] grid;
    public static string[,] tiles;

    public static int gridWidth { get { return 10; } }
    public static int gridHeight { get { return 20; } }

    Vector2 position;                                   //positie van de grid zelf

    // Start is called before the first frame update
    void Start()
    {
        position = Vector2.zero;
        grid = new string[gridWidth, gridHeight];
    }

    public bool isOccupied(int x, int y)             //moet aangeroepen worden op t moment dat iets zich wil verplaatsen. De 'targetposition' zijn dan de meegegeven x en y waarden die de methode nodig heeft
    {
        if (grid[x, y] != null)                     // 'null' wordt nog vervangen door 't lege vakje wat wordt afgelezen uit de tekstbestanden van ieder object
        {
            return true;
        }
        else
            return false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
