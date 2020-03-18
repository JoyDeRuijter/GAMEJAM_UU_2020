using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
      EventController.OnNpcInteracted += NpcInteracted;
   }
   
   public TalkGoal(int amountNeeded, int npcID, Quest quest) : this(amountNeeded, quest)
   {
      this.npcID = npcID;
   }

   void NpcInteracted(int npcID)
   {
      if (this.npcID == npcID || this.npcID == 0)
      {
         //Debug.Log("the npc interacted with, is the correct one?");
         Increment(1);
         if (this.completed)
         {
            EventController.OnNpcInteracted -= NpcInteracted;
         }
      }
   }

}
