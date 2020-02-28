using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    //public float cellWidth = 1.56574255228F;                      //vg na de re-scale nu niet meer nodig
    //public float cellHeight = 1.56574255228F;

    public int PosX;
    public int PosY;

    void Start()
    {

    }

    void Update()
    {
        //this.transform.position = new Vector3(cellWidth * PosX, cellHeight * PosY);        //In tetris bewogen we de tetromino ook niet steeds in de grid. We veranderen steeds te vector, en om vervolgens de collision te checken gebruiken we die vector    
        
    }
}
