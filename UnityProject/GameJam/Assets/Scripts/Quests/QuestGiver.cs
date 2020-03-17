using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    [SerializeField] private string questName;
    private QuestController questController;
    private Quest quest;

    private bool questGiven;
    // Start is called before the first frame update
    void Start()
    {
        questController = FindObjectOfType<QuestController>();
        EventController.OnQuestCompleted += Completed;

        questGiven = false;
    }

    public void GiveQuest()
    {
        if (questGiven != true)
        {
            quest = questController.AssignQuest(questName);
            questGiven = true;
        }
        //    TODO: Must no longer be able to give quests
    }

    public void Completed(Quest quest)
    {
        if (this.quest != null && quest == this.quest)
        {
            //    TODO: Must no longer be able to give quests
        }
    }
}
