using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiMainManager : MonoBehaviour
{
    public Button restartButton;
    
    private GameManager gameManager;
    private void Start()
    {
        
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
}
