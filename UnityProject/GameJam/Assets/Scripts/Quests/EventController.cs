using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    public static event System.Action<int> OnNpcInteracted = delegate {  };
    public static event System.Action<int> OnObjectFound = delegate {  };
    public static event System.Action<Quest> OnQuestProgressedChanged = delegate {  };
    public static event System.Action<Quest> OnQuestCompleted = delegate {  }; 

    public static void NpcInteracted(int npcID)
    {
        OnNpcInteracted(npcID);
    }
    
    public static void ObjectFound(int objID)
    {
        OnObjectFound(objID);
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
