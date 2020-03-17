using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    public static event System.Action<int> OneNpcInteracted = delegate {  };
    public static event System.Action<Quest> OnQuestProgressedChanged = delegate {  };
    public static event System.Action<Quest> OnQuestCompleted = delegate {  }; 

    public static void NpcInteracted(int npcID)
    {
        OneNpcInteracted(npcID);
    }
    
    public static void QuestProgressChanged(Quest quest)
    {
        OnQuestProgressedChanged(quest);
    }
    
    public static void QuestCompleted(Quest quest)
    {
        OnQuestCompleted(quest);
    }
}
