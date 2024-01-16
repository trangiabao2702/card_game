using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystemService : MonoBehaviour
{
    public static PlayerState PlayerStates;
    string SaveFilePath = "PlayerStates.txt";

    void Save()
    {
        string savePlayerState = JsonUtility.ToJson(PlayerStates);
        File.WriteAllText(SaveFilePath, savePlayerState);

        Debug.Log("Save file created at: " + SaveFilePath);
    }

    void Load()
    {
        if (File.Exists(SaveFilePath))
        {
            string loadPlayerState = File.ReadAllText(SaveFilePath);
            PlayerStates = JsonUtility.FromJson<PlayerState>(loadPlayerState);
        }
        else
            Debug.Log("There is no save files to load!");
    }
}
