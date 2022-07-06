using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
  public int difficulty;
  private Button button;
  public TextMeshProUGUI emptyNameErrorText;
  
  // Start is called before the first frame update
  void Start()
  {
    button = GetComponent<Button>();
    button.onClick.AddListener(SetDifficulty);
  }

  void SetDifficulty()
  {
    if (string.IsNullOrEmpty(DataManager.Instance.UserName))
    {
      emptyNameErrorText.gameObject.SetActive(true);
    }
    else
    {
      DataManager.Instance.Level = difficulty;
      SceneManager.LoadSceneAsync(1);
    }
  }
}