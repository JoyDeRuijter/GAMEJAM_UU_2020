using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour
{
    //    This script will be generating strings of random length and random symbols, and place them in the correct position within the book.
    //    The length of each word should be saved, so we know where the next word should go, and when to start a new line.
    // TODO: Fix the position of instantiation.
    //    Preferably, It should check whether the next word could still fit on the same line (withing the correct page)
    //    If so, the words must be instantiated within 'hitboxes' of the pages. Is this possible???

    public GameObject word;
    private Vector3 bookPosition;
    private Vector3 wordPosition;
    
    public void Start()
    {
        CreateWords();
    }
    
    
    public void CreateWords()
    {
        for (int i = 0; i < 1; i++)
        {
            GameObject wordClone = Instantiate(word, transform.position, Quaternion.identity);
        }
    }
}
