using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuNav : MonoBehaviour
{
    [SerializeField]private GameObject leaderboardContainer;
    [SerializeField]private GameObject menuBtns;
    [SerializeField]private GameObject menuTitle;


    
    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void LeaderBoard()
    {
        menuBtns.SetActive(false);
        menuTitle.SetActive(false);
        leaderboardContainer.SetActive(true);
    }

    public void BackToMenu()
    {
        leaderboardContainer.SetActive(false);
        menuBtns.SetActive(true);
        menuTitle.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
