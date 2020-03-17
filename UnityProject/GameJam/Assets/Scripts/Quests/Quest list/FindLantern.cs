using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Sharing;

public class FindLantern : Quest
{
    void Awake()                //As soon as its added, everything must be immediately available
    {
        questName = "Find Lantern";
        description = "Just a simple task to test your basic human knowledge";
        //skillRewards = FindObjectOfType<GameManager>().scoreFriends;
        goal = new FindGoal(1, this);
        
        //EventController.NpcInteracted(0);
    }

    public override void Complete()
    {
        GrantReward("friends", 10, null, 0);
        base.Complete();
    }
}