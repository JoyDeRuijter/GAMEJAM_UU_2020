using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //This class makes instances of all 4 types of scores, and saves them over all scenes.
    //    (scores can be changed by using...    'FinObjectOfType<GameManager>.scoreUni +=10;'    ...for example.
    
    public static GameManager instance;
    
    public int scoreUni;
    public int scoreFriends;
    public int scoreParty;
    public int scoreLove;

    void Awake()
    {
        MakeSingleton();
    }

    private void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
