﻿using System;
using System.Text;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    List<string> textLines;
    StreamReader fileReader;
    private string path;
    private string line;

    private int ID;
    
    void Start()
    {
        textLines = new List<string>();
        /*path = "Assets/Text/NPC/NPC_Dialogue" + 0 + ".txt";
        fileReader = new StreamReader(path);
        line = fileReader.ReadLine();*/
        
        Console.WriteLine(line);
    }

    void Update()
    {
        //Console.WriteLine(line);
        //Debug.Log(line);
    }

    public void NPC(int ID)
    {
        path = "Assets/Text/NPC/NPC_Dialogue" + ID + ".txt";
        fileReader = new StreamReader(path); 
        line = fileReader.ReadLine(); 
        textLines.Add(line); 
        fileReader.ReadLine();
        Debug.Log(line);
    }

    public void Object(int ID)
    {
        path = "Assets/Text/Object/Object_Description" + ID + ".txt";
        fileReader = new StreamReader(path); 
        line = fileReader.ReadLine(); 
        textLines.Add(line); 
        fileReader.ReadLine();
        Debug.Log(line);
    }
}
