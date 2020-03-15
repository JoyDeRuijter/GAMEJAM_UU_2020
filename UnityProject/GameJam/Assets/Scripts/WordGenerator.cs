using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour
{
    //    This script will be generating strings of random length and random symbols, and place them in the correct position within the book.
    //    The length of each word should be saved, so we know where the next word should go, and when to start a new line.
    // TODO: Fix the position of instantiation

    public GameObject word;
    
    // public static bool openMenu;
    
    public void Start()
    {
        CreateWords();
    }
    
    
    public void CreateWords()
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject wordClone = Instantiate(word, new Vector3(1 + i*1000000000000000, 1, 1), Quaternion.identity);
        }
    }
}
