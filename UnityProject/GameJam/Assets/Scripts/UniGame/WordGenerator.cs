using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class WordGenerator : MonoBehaviour
{
    //    Currently only generates random symbols. Should 'GenerateText()' and 'WriteText()' be moved here from PageGrid,
    //        or should 'NextSymbol()' be moved to PageGrid

    void Start()
    {
        
    }

    private void Update()
    {
        
    }
    
    /*public void WriteText(int x, int y)
    {
        //    Should place strings of singular symbols..
        //    We could instantiate tiny canvasses. Text can be placed inside these, and we could add collision to these (for hovering)
        //    Will the positioning work, though?
        
        //    this method profits from the previous method's for-loop. Position must still be altered.
        GameObject SymbolClone = (GameObject)Instantiate(symbol, pagePosition, Quaternion.identity);
        Debug.Log(pageGrid[x,y]);
        SymbolClone.GetComponent<Symbol>().symbolText.GetComponent<UnityEngine.UI.Text>().text= pageGrid[x, y];
        Debug.Log(SymbolClone.GetComponent<Symbol>().symbolText.GetComponent<UnityEngine.UI.Text>().text);
    }*/

    public string NextSymbol()
    {
        int symbolNumber = Random.Range(1, 26);
        switch (symbolNumber)
        {
            case 1:
                return "a";
                break;
            case 2:
                return "b";
                break;
            case 3:
                return "c";
                break;
            case 4:
                return "d";
                break;
            case 5:
                return "e";
                break;
            case 6:
                return "f";
                break;
            case 7:
                return "g";
                break;
            case 8:
                return "h";
                break;
            case 9:
                return "i";
                break;
            case 10:
                return "j";
                break;
            case 11:
                return "k";
                break;
            case 12:
                return "l";
                break;
            case 13:
                return "m";
                break;
            case 14:
                return "n";
                break;
            case 15:
                return "o";
                break;
            case 16:
                return "p";
                break;
            case 17:
                return "q";
                break;
            case 18:
                return "r";
                break;
            case 19:
                return "s";
                break;
            case 20:
                return "t";
                break;
            case 21:
                return "u";
                break;
            case 22:
                return "v";
                break;
            case 23:
                return "w";
                break;
            case 24:
                return "x";
                break;
            case 25:
                return "y";
                break;
            case 26:
                return "z";
                break;
            default:
                return "";
                break;
        }
    }
}
