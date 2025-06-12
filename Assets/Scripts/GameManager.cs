using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string PlayerName;
    public string PlayerHighScore;
    public int HighScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScores();
    }

    [System.Serializable]
    class SaveData
    {
        public string PlayerName;
        public string PlayerHighScore;
        public int HighScore;
    }

    public void SetName(string name)
    {
        PlayerName = name;
    }

    public void SetHighScore(int score)
    {
        PlayerHighScore = PlayerName;
        HighScore = score;
    }

    public void SaveScores()
    {
        SaveData data = new SaveData();
        data.PlayerName = PlayerName;
        data.PlayerHighScore = PlayerHighScore;
        data.HighScore = HighScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScores()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            PlayerName = data.PlayerName;
            PlayerHighScore = data.PlayerHighScore;
            HighScore = data.HighScore;
        }
    }

}
