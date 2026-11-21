using System.IO;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    string saveFilePath;
    PlayerData currentData = new PlayerData();

    void Awake()
    {
        saveFilePath = Path.Combine(Application.dataPath, "ManaChess/Application/", "playerdata.json");
        Debug.Log(saveFilePath);
        LoadData();
    }

    public PlayerData GetData()
    {
        return currentData;
    }

    public void LoadData()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            currentData = JsonUtility.FromJson<PlayerData>(json);
            Debug.Log("load data successful");
        }
        else
        {
            SaveData(currentData);
        }
    }

    public void SaveData(PlayerData dataToSave)
    {
        currentData = dataToSave;
        string json = JsonUtility.ToJson(currentData);
        File.WriteAllText(saveFilePath, json);
        Debug.Log($"save file to {saveFilePath}");
    }
}
