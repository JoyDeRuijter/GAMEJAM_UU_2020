using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour

{
    public GameObject npc;
    public GameObject npc1;
    public GameObject npc2;
    public GameObject npc3;
    //public Sprite[] characters;

    /*public void makeRandomCharacter()
    {
        int arrayIdx = Random.Range(0, characters.Length);
        Sprite character = characters[arrayIdx];
        string characterName = character.name;

        GameObject newCharacter = Instantiate(npc);

        newCharacter.name = characterName;
        
        newCharacter.GetComponent<SpriteRenderer>().sprite = character;
    }*/


    void Start()
    
    {
        Instantiate(npc);
        Instantiate(npc1);
        Instantiate(npc2);
        Instantiate(npc3);
        



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
