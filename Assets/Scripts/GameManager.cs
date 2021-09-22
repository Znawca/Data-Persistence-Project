using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int highScore;
    public string highScoreName;


    public string newName;

    private void Awake()
    {
        // if object exist destroy copy
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // if not dont destroy on load

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadGame();
    }

    public void CheckIfHighScore(int score)
    {
        if (score > highScore)
        {
            highScore = score;
            highScoreName = newName;
        }
    }

    [System.Serializable]
    class SaveData
    {
        public string highScoreNameSave;
        public int highScoreSave;
    }

    public void SaveGame()
    {
        SaveData data = new SaveData();
        data.highScoreNameSave = highScoreName;
        data.highScoreSave = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScoreName = data.highScoreNameSave;
            highScore = data.highScoreSave;
        }
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }
}
