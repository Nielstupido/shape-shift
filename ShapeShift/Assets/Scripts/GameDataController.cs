using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDataController : MonoBehaviour
{
    [SerializeField] private GameObject usernamePanel;
    public static GameData gameData = new GameData();
    private LeaderboardController leaderboardController;
    private int[] playerIdentifier = new int[3];
    private int[] member_ID_ = new int[4];
    public static bool isNewUser;

    public static int HighScore
    {
        get{return gameData.highScore;} 
        set{gameData.highScore = value; GameDataFunctions.SaveData();}
    }

    public static int MemberID
    {
        get{return gameData.member_id;} 
        set{gameData.member_id = value; GameDataFunctions.SaveData();}
    }

    public static string UserName
    {
        get{return gameData.username;} 
        set{gameData.username = value; GameDataFunctions.SaveData();}
    }

    public static string PlayerIdentifier
    {
        get{return gameData.playerIdentifier;} 
        set{gameData.playerIdentifier = value; GameDataFunctions.SaveData();}
    }

    void Start()
    {
        leaderboardController = FindObjectOfType<LeaderboardController>();
        gameData = GameDataFunctions.LoadData();
        if(gameData.playerIdentifier.Equals("empty"))
        {
            isNewUser = true;
            usernamePanel.SetActive(true);
            GenerateID();
            GenerateMemberID();
            GameDataFunctions.SaveData();
            gameData = GameDataFunctions.LoadData();
        }
        else
        {
            isNewUser = false;
            leaderboardController.StartSession();
        }
    }

    void GenerateID()
    {
        playerIdentifier[0] = Random.Range(0, 10);
        playerIdentifier[1] = Random.Range(10, 100);
        playerIdentifier[2] = Random.Range(100, 1000);
        gameData.playerIdentifier = playerIdentifier[0].ToString() + playerIdentifier[1].ToString() + playerIdentifier[2].ToString();
    }

    void GenerateMemberID()
    {
        member_ID_[0] = Random.Range(0, 10);
        member_ID_[1] = Random.Range(10, 99);
        member_ID_[2] = Random.Range(100, 499);
        member_ID_[3] = Random.Range(500, 1000);
        gameData.member_id = int.Parse(member_ID_[0].ToString() + member_ID_[1].ToString() + member_ID_[2].ToString() + member_ID_[3].ToString());
    }
}

