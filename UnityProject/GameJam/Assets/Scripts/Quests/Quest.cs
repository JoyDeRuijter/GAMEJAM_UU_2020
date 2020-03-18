using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    //TODO: NAME, DESCRIPTION, GOAL, REWARD

    public string questName;
    public string description;
    public Goal goal;
    public bool completed;
    public List<string> skillRewards;

    public virtual void Complete()
    {
        completed = true;
        Debug.Log("Quest completed!");
        EventController.QuestCompleted(this);
    }

    public void GrantReward(string rewardType, int reward, string lossType, int loss)
    {
        switch (rewardType)
        {
            case "friends":
                FindObjectOfType<GameManager>().scoreFriends += reward;
                Debug.Log("New friends-score: " + FindObjectOfType<GameManager>().scoreFriends);
                break;
            case "party":
                FindObjectOfType<GameManager>().scoreParty += reward;
                Debug.Log("New party-score: " + FindObjectOfType<GameManager>().scoreParty);
                break;
            case "uni":
                FindObjectOfType<GameManager>().scoreUni += reward;
                Debug.Log("New uni-score: " + FindObjectOfType<GameManager>().scoreUni);
                break;
            case "love":
                FindObjectOfType<GameManager>().scoreLove += reward;
                Debug.Log("New love-score: " + FindObjectOfType<GameManager>().scoreLove);
                break;
            case null:
                break;
            default:
                break;
        }

        switch (lossType)
        {
            case "friends":
                FindObjectOfType<GameManager>().scoreFriends -= loss;
                Debug.Log("New friends-score: " + FindObjectOfType<GameManager>().scoreFriends);
                break;
            case "party":
                FindObjectOfType<GameManager>().scoreParty -= loss;
                Debug.Log("New party-score: " + FindObjectOfType<GameManager>().scoreParty);
                break;
            case "uni":
                FindObjectOfType<GameManager>().scoreUni -= loss;
                Debug.Log("New uni-score: " + FindObjectOfType<GameManager>().scoreUni);
                break;
            case "love":
                FindObjectOfType<GameManager>().scoreLove -= loss;
                Debug.Log("New love-score: " + FindObjectOfType<GameManager>().scoreLove);
                break;
            case null:
                break;
            default:
                break;
        }

        Destroy(this);            //    Component to quest-controller object. When completed, quest component may be destroyed.
    }
    
}
