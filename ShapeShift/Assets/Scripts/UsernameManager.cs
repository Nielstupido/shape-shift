using System.Collections;
using System.Collections.Generic;
using LootLocker.Requests;
using UnityEngine.UI;
using UnityEngine;

public class UsernameManager : MonoBehaviour
{
    [SerializeField]private InputField usernameInput;
    private LeaderboardController leaderboardController;
    private int leaderboardID = 4470;

    public void VerifyUsername()
    {
        leaderboardController = FindObjectOfType<LeaderboardController>();
        GameDataController.UserName = usernameInput.text;
        leaderboardController.StartSession();
        gameObject.SetActive(false);

        /*
        LootLockerSDKManager.StartSession(GameDataController.PlayerIdentifier, (response) =>
        {
            if (response.success)
            {
                LootLockerSDKManager.GetMemberRank(leaderboardID, usernameInput.text, (response) =>
                {
                    if (response.statusCode == 200) 
                    {
                        usernameInput.text = ">Username already existed!<";
                    } 
                    else 
                    {

                    }
                });
            }
            else
            {
                Debug.Log("failed to start sessions" + response.Error);
            }
        });*/
    }
}
