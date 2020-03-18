using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportNPC : MonoBehaviour
{
    private NPC npc;
    [SerializeField] private string NpcName;
    [SerializeField] public int dayNumber = 1;            //    would preferably put this somewhere else..


    public int lineCount;            //    would preferably read this from the directory
    public int choiceCount;
    
    void Start()
    {
        npc = GetComponent<NPC>();

        Generate();
    }

    void Generate()
    {
        //lineCount = 4;
    }
    
    void Update()
    {
        
    }
}