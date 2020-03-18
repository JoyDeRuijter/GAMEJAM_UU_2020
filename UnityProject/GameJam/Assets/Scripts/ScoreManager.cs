using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private Text scoreUni, scoreFriends, scoreParty, scoreLove;

    private GameManager gameManager;
    
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        this.scoreUni.text = "University score:" + gameManager.scoreUni.ToString();
        this.scoreFriends.text = "Friends score:" + gameManager.scoreFriends.ToString();
        this.scoreParty.text = "Popularity score:" + gameManager.scoreParty.ToString();
        this.scoreLove.text = "Love score:" + gameManager.scoreLove.ToString();
    }
}
