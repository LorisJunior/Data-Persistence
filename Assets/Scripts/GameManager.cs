using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string recordName;
    public string playerName;
    public int score;

    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        score = 0;
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadGame();
    }

    class SaveRecord
    {
        public string name;
        public int score;
    }

    public void SaveGame()
    {
        SaveRecord record = new SaveRecord();

        record.name = playerName;
        record.score = score;

        string json = JsonUtility.ToJson(record);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveRecord data = JsonUtility.FromJson<SaveRecord>(json);

            recordName = data.name;
            score = data.score;
        }
    }

    public string BestScore(int points)
    {
        if (points > score)
        {
            score = points;
            recordName = playerName;
            SaveGame();
            return $"Best Score: {playerName} : {score}";
        }
        else
        {
            return $"Best Score: {recordName} : {score}";
        }
    }
}
