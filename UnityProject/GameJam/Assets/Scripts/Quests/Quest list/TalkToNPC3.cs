using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Sharing;

public class TalkToNPC3 : Quest
{
    void Awake()                //As soon as its added, everything must be immediately available
    {
        questName = "Meet NPC3";
        description = "You should get to know them..";
        //skillRewards = FindObjectOfType<GameManager>().scoreFriends;
        goal = new TalkGoal(1, 3, this);
        
        //EventController.NpcInteracted(0);
    }

    public override void Complete()
    {
        GrantReward("friends", 5, null, 0);
        base.Complete();
    }
}