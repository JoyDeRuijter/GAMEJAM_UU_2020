using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class QuestController : MonoBehaviour
{
    public List<Quest> assignedQuests = new List<Quest>();

    [SerializeField]
    private QuestUIItem questUIItem;
    [SerializeField]
    private Transform questUIParent;
    [SerializeField]
    private GameObject questCanvas;
    
    private QuestDatabase questDatabase;

    private void Start()
    {
        questDatabase = GetComponent<QuestDatabase>();
    }

    void Update()
    {
        bool isEmpty = !assignedQuests.Any(quest => !quest.completed);

        if(isEmpty)
        {
            //    Close quest canvas
            questCanvas.SetActive(false);
        }
        else if (!isEmpty)
        {
            //    Open quest canvas
            questCanvas.SetActive(true);
        }
    }
        
    
    public Quest AssignQuest(string questName)
    {
        if (assignedQuests.Find(quest => quest.questName == questName))
        {
            Debug.Log("Quest already assigned.");
            return null;
        }

        Quest questToAdd = (Quest)gameObject.AddComponent(System.Type.GetType(questName));
        assignedQuests.Add(questToAdd);
        questDatabase.AddQuest(questToAdd);

        QuestUIItem questUIClone = Instantiate(questUIItem, questUIParent);
        questUIClone.Setup(questToAdd);
        
        return questToAdd;
    }
}
