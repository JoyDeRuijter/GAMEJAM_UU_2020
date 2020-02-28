using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public float cellWidth = 1.56574255228F;                      //misschien kunnen we op 'n makkelijkere manier bij deze waarden komen
    public float cellHeight = 1.56574255228F;

    public int PosX;
    public int PosY;

    void Start()
    {

    }

    void Update()
    {
        this.transform.position = new Vector3(cellWidth * PosX, cellHeight * PosY);        //In tetris bewogen we de tetromino ook niet steeds in de grid. We veranderen steeds te vector, en om vervolgens de collision te checken gebruiken we die vector    
        
    }
}
