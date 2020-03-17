using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkGoal : Goal
{
   public int npcID;

   public TalkGoal(int amountNeeded, Quest quest)
   {
      countCurrent = 0;
      countNeeded = amountNeeded;
      this.quest = quest;
      completed = false;
      EventController.OneNpcInteracted += NpcInteracted;
   }
   
   public TalkGoal(int amountNeeded, int npcID, Quest quest) : this(amountNeeded, quest)
   {
      this.npcID = npcID;
   }

   void NpcInteracted(int npcID)
   {
      if (this.npcID == npcID)
      {
         Increment(1);
      }
   }

}
