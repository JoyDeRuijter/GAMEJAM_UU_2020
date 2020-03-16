using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;

public class PageGrid : MonoBehaviour
{
    //    This method will create two grids; one for each page of the book.
    //    Each element in the grid un-separated by 'spacebars' (""-strings) are words.
    //    Words/symbols must be all hovered-over in reading-order if the player wants to win.
    //    There will be a time-limit for the player to complete the mini-game, but that'll be handled elsewhere.
    //    There will be only ONE grid for both pages; once the y-coordinate pages a certain threshold, the positions of
    //        the following elements will be altered to appear on the second page.
    
    public string[,] pageGrid;
    public static int gridWidth { get { return 8; } }        //    Temporary values
    public static int gridHeight { get { return 6; } }        //    Temporary values

    Vector2 pagePosition;        //    Private or public? Must they be accessed from within unity?

    private WordGenerator wordGenerator;
    private int wordLength;                    //Random length per word
    private int symbolCount;                   //Current symbol amount of the current word

    public GameObject symbol;
    
    void Start()
    {
        wordGenerator = FindObjectOfType<WordGenerator>();
        
        pageGrid = new string[gridWidth, gridHeight];
        pagePosition = new Vector2(100,100);

        Generate();
    }

    void Generate()
    {
        wordLength = Random.Range(3, 7);
        symbolCount = 0;
        
        GenerateText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateText()                        //    Should this method be moved?
    {
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                if (symbolCount <= wordLength)
                {
                    pageGrid[x, y] = wordGenerator.NextSymbol();        //If this method is handled elsewhere, shouldnt GenerateText be too??
                    symbolCount++;
                }
                else if (symbolCount > wordLength)
                {
                    pageGrid[x, y] = "";
                    wordLength = Random.Range(2, 8);                    //New word is 'initialised', with its own length.
                    symbolCount = 0;                                    //The new word will have no symbols yet.
                }
                
                //A method could be called here to write the symbols down in the right place.
                WriteText(x,y);
                
                //Debug.Log(x + ", " + y + ", " + pageGrid[x, y]);
            }
        }
    }

    public void WriteText(int x, int y)
    {
        //    Should place strings of singular symbols..
        //    We could instantiate tiny canvasses. Text can be placed inside these, and we could add collision to these (for hovering)
        //    Will the positioning work, though?
        
        //    this method profits from the previous method's for-loop. Position must still be altered.
        GameObject SymbolClone = Instantiate(symbol, pagePosition, Quaternion.identity);
        
        SymbolClone.GetComponent<Symbol>().SetSymbol(pageGrid[x, y]);
        SymbolClone.GetComponent<Symbol>().symbolPosition = pagePosition;
    }
}
