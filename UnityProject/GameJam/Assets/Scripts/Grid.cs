using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public static string[,] grid;
    public static string[,] tiles;
    public static int gridWidth { get { return 10; } }
    public static int gridHeight { get { return 20; } }

    public int cellWidth = 32;
    public int cellHight = 32;

    Vector2 position;

    // Start is called before the first frame update
    void Start()
    {
        position = Vector2.zero;
        grid = new string[gridWidth, gridHeight];
    }

    public bool isOccupied(int x, int y)
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
        isOccupied(gridWidth, gridHeight);
    }
}
