using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameData
{
    public int highScore;
    public int member_id;
    public string username;
    public string playerIdentifier;
}

public class GameDataFunctions
{
    public static void SaveData()
    {
        /*
        BinaryFormatter bf = new BinaryFormatter(); 
        FileStream file = File.Create(Application.persistentDataPath 
                    + "/GameData.dat"); 
        GameData data = new GameData();
        data.highScore = GameDataManager.HighScore;
        data.username =  GameDataManager.UserName;
        data.playerIdentifier =  GameDataManager.PlayerIdentifier;
        bf.Serialize(file, data);
        file.Close();*/
        PlayerPrefs.SetString("User_name", GameDataController.UserName);
        PlayerPrefs.SetInt("HighScore", GameDataController.HighScore);
        PlayerPrefs.SetInt("Member-ID", GameDataController.MemberID);
        PlayerPrefs.SetString("Player-ID", GameDataController.PlayerIdentifier);
    }


    public static GameData LoadData()
    {
        /*
        if (File.Exists(Application.persistentDataPath 
                    + "/GameData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = 
                    File.Open(Application.persistentDataPath 
                    + "/GameData.dat", FileMode.Open);
            GameData data = (GameData)bf.Deserialize(file);
            file.Close();
            return data;
        }
        else
        {
            GameData data = new GameData();
            data.highScore = 0;
            data.username = "empty";
            data.playerIdentifier = "empty";
            return data;
        }*/
        GameData data = new GameData();

        if(PlayerPrefs.HasKey("User_name"))
        {
            data.username = PlayerPrefs.GetString("User_name");
            data.highScore = PlayerPrefs.GetInt("HighScore");
            data.member_id = PlayerPrefs.GetInt("Member-ID");
            data.playerIdentifier = PlayerPrefs.GetString("Player-ID");
            return data;
        }
        else
        {
            PlayerPrefs.SetString("User_name", "empty");
            PlayerPrefs.SetInt("HighScore", 0);
            PlayerPrefs.SetInt("Member-ID", 0);
            PlayerPrefs.SetString("Player-ID", "empty");
            data.username = PlayerPrefs.GetString("User_name");
            data.highScore = PlayerPrefs.GetInt("HighScore");
            data.member_id = PlayerPrefs.GetInt("Member-ID");
            data.playerIdentifier = PlayerPrefs.GetString("Player-ID");
            return data;
        }
    }
}
