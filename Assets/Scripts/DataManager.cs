using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
  public static DataManager Instance;

  public string UserName;
  public string HighScoreUserName;
  public int HighScoreValue;
  public int Level;

  private void Awake()
  {
    if (Instance != null)
    {
      Destroy(gameObject);
      return;
    }

    Instance = this;
    DontDestroyOnLoad(gameObject);
    
    LoadHighScore(); 
  }
  
  [System.Serializable]
  class SaveData
  {
    public string UserName;
    public int HighScore;
  }
  
  public void SaveHighScore()
  {
    var data = new SaveData
    {
      UserName = HighScoreUserName,
      HighScore = HighScoreValue
    };

    string json = JsonUtility.ToJson(data);
  
    File.WriteAllText(Application.persistentDataPath + "/highScore.json", json);
  }
  
  public void LoadHighScore()
  {
    string path = Application.persistentDataPath + "/highScore.json";
    if (File.Exists(path))
    {
      string json = File.ReadAllText(path);
      SaveData data = JsonUtility.FromJson<SaveData>(json);

      HighScoreUserName = data.UserName;
      HighScoreValue = data.HighScore;
    }
  }
}