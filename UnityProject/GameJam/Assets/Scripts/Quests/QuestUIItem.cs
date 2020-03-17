using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestUIItem : MonoBehaviour
{
    [SerializeField]
    private Text questName, questProgress;

    private Quest quest;

    private void Start()
    {
        EventController.OnQuestCompleted += QuestCompleted;
        EventController.OnQuestProgressedChanged += UpdateProgress;
    }

    public void Setup(Quest questToSetup)
    {
        this.quest = questToSetup;                    //    Does this work?
        
        questName.text = questToSetup.questName;
        questProgress.text = questToSetup.goal.countCurrent + "/" + questToSetup.goal.countNeeded;
    }

    public void UpdateProgress(Quest quest)
    {
        Debug.Log(this.quest.questName);
        Debug.Log(quest.questName);
        //Debug.Log(this.quest.questName + " is not " + quest.questName);
        if (this.quest == quest)
        {
            Debug.Log("Updating quest progress");
            questProgress.text = quest.goal.countCurrent + "/" + quest.goal.countNeeded;
        }
    }

    public void QuestCompleted(Quest quest)
    {
        if (this.quest == quest)
        {
            Destroy(this.gameObject, 1F);
        }
    }
}
