using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Word : MonoBehaviour
{
    //    Each object if this type will be contain a string of random length and symbols (generated elsewhere) and a hitbox, so it may be 'marked' when colliding with the cursor.
    // TODO: Each word must be 'marked' when hovered over/clicked on. They can only be 'marked' in order from left to right, and top to bottom.

    public Text wordText;
    
    public string wordString;
    public int wordLength;
    
    void Start()
    {
        wordString = "";
        wordLength = Random.Range(3, 7);
        
        RandomizeWord();
    }

    private void Update()
    {
        wordText.GetComponent<UnityEngine.UI.Text>().text = wordString;
        Debug.Log(wordString);
    }

    string RandomizeWord()
    {
        for (int i = 0; i < wordLength; i++)
        {
            wordString += nextSymbol();
        }
        return wordString;
    }

    string nextSymbol()
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
