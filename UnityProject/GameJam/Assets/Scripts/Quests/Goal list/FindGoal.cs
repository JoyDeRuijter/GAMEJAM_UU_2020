using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindGoal : Goal
{
    public int objID;

    public FindGoal(int amountNeeded, Quest quest)
    {
        countCurrent = 0;
        countNeeded = amountNeeded;
        this.quest = quest;
        completed = false;
        EventController.OnObjectFound += ObjectFound;
    }
   
    public FindGoal(int amountNeeded, int objID, Quest quest) : this(amountNeeded, quest)
    {
        this.objID = objID;
    }

    void ObjectFound(int npcID)
    {
        if (this.objID == npcID)
        {
            Increment(1);
            if (this.completed)
            {
                EventController.OnObjectFound -= ObjectFound;
            }
        }
    }

}