using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDatabase : MonoBehaviour
{
    //    What quests have progress and what quests have been completed?
    public Dictionary<string, int[]> Quests = new Dictionary<string, int[]>();

    private void Awake()
    {
        EventController.OnQuestProgressedChanged += UpdateQuestData;
    }

    public bool Completed(string questName)
    {
        if (Quests.ContainsKey(questName))
        {
            return System.Convert.ToBoolean(Quests[questName][0]);
        }
        return false;
    }

    public void AddQuest(Quest quest)
    {
        Quests.Add(quest.questName, new int[] { 0 , 0 });
    }

    public void UpdateQuestData(Quest quest)
    {
        Quests[quest.questName] = new int[] { System.Convert.ToInt32(quest.completed) , quest.goal.countCurrent };
        Debug.Log("Data updated for: " + quest.questName);
    }
    
}
