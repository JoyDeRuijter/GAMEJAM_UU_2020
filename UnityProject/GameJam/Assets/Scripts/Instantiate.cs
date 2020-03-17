using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour

{
    public GameObject npc;
    public Sprite[] characters;

    public void makeRandomCharacter()
    {
        int arrayIdx = Random.Range(0, characters.Length);
        Sprite character = characters[arrayIdx];
        string characterName = character.name;

        GameObject newCharacter = Instantiate(npc);

        newCharacter.name = characterName;
        
        newCharacter.GetComponent<SpriteRenderer>().sprite = character;
    }


    void Start()
    
    {
        makeRandomCharacter();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
