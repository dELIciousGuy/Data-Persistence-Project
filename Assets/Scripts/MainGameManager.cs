using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class MainGameManager : MonoBehaviour
{
    public static MainGameManager Instance;

    public string playerName;
    public string highPlayer;
    public int highScore;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadGame();
    }

    [System.Serializable]
    class SaveData
    {
        public string highPlayer;
        public int highScore;
    }

    public void SaveGame(int points, string name)
    {
        if(points > highScore)
        {
            SaveData data = new SaveData();

            data.highPlayer = name;
            data.highScore = points;

            string json = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }
    }


    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highPlayer = data.highPlayer;
            highScore = data.highScore;
        }
    }
}
