using LootLocker.Requests;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class LeaderboardController : MonoBehaviour
{
    [SerializeField]private Text highScore;
    [SerializeField]private Text userRank;
    [SerializeField]List<Text> scores = new List<Text>();
    [SerializeField]List<Text> usernames = new List<Text>();
    [SerializeField]List<Image> row = new List<Image>();
    private int timeOutConnection;
    private int leaderboardID = 4470;
    private int playerRank;
    private int playerScore;
    private int count;

    void Start()
    {   
        timeOutConnection = 0;
        count = 6;
    }

    public void StartSession()
    {
        LootLockerSDKManager.StartSession(GameDataController.PlayerIdentifier, (response) =>
        {
            if (response.success)
            {
                timeOutConnection = 0;
                count = 6;
                highScore.text = GameDataController.HighScore.ToString();

                if(GameDataController.isNewUser)
                {
                    SetPlayerName();
                }

                UpdatePlayerScore();
                RefreshLeaderboard();
            }
            else
            {
                Debug.Log("failed to start sessions" + response.Error);
            }
        });
    }

    void SetPlayerName()
    {
        LootLockerSDKManager.SetPlayerName(GameDataController.UserName, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Successfully set player name");
            } else
            {
                Debug.Log("Error setting player name");
            }
        });
    }

    void UpdatePlayerScore()
    {
        LootLockerSDKManager.SubmitScore(GameDataController.MemberID.ToString(), GameDataController.HighScore, leaderboardID, (response) =>
        {
            if (response.statusCode == 200) {
                GameDataController.MemberID = int.Parse(response.member_id);
                Debug.Log("Successful");
            } else {
                Debug.Log("failed: " + response.Error);
            }
        });
    }

    void RefreshLeaderboard()
    {
        LootLockerSDKManager.GetMemberRank(leaderboardID, GameDataController.MemberID.ToString(), (response) =>
        {
            if (response.success)
            {
                timeOutConnection = 0;

                playerRank = response.rank;
                playerScore = response.score;

                LootLockerSDKManager.GetScoreList(leaderboardID, count, (response) =>
                {
                    if (response.statusCode == 200)
                    {
                        LootLockerLeaderboardMember[] playersData = response.items;

                        if(playerRank > count)
                        {
                            for(int i = 0; i < playersData.Length; i++)
                            {
                                scores[i].text = playersData[i].score.ToString();
                                usernames[i].text = playersData[i].player.name;
                            }
                            scores[count-1].text = playersData[count-1].score.ToString();
                            usernames[count-1].text = GameDataController.UserName;
                            userRank.text = playerRank.ToString();

                            row[5].color = Color.yellow;
                            var tempColor = row[5].color;
                            tempColor.a = 7f;
                            row[5].color = tempColor;
                        }
                        else
                        {
                            for(int i = 0; i < playersData.Length; i++)
                            {
                                scores[i].text = playersData[i].score.ToString();
                                usernames[i].text = playersData[i].player.name;
                                if(playersData[i].player.name.Equals(GameDataController.UserName) && i != 0)
                                {
                                    row[i].color = Color.yellow;
                                    var tempColor = row[i].color;
                                    tempColor.a = 6f;
                                    row[i].color = tempColor;
                                }
                            }

                            if(playersData.Length < count)
                            {
                                for(int i = playersData.Length; i < count; i++)
                                {
                                    scores[i].text = "0";
                                    usernames[i].text = "None";
                                }
                            }
                        }
                    }
                    else
                    {
                        Debug.Log("failed: " + response.Error);
                    }
                });
            }
            else
            {
                userRank.text = "ngeks";
                timeOutConnection++;
                RefreshLeaderboard();
            }
        });
    }
}
