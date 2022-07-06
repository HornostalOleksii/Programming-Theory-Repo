using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Button = UnityEngine.UI.Button;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public bool isGameActive = false;
    public int spawnRate = 1;
    //public int maxEnemies = 3;
    
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public Button backToMenuButton;
    
    public AudioSource backgroundSound;
    public AudioSource gameOverSound;

    private void Start()
    {
        StartGame(); 
    }

    public void StartGame()
    {
        //spawnRate /= difficulty;
        //titleScreen.gameObject.SetActive(false);
        isGameActive = true;
        UpdateScore(0);
        //InvokeRepeating("SpawnTargets2", 1, 1);
        StartCoroutine(SpawnTargets());
    }

    public void GameOver()
    {
        isGameActive = false;
        backgroundSound.Stop();
        gameOverSound.PlayOneShot(gameOverSound.clip);
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        backToMenuButton.gameObject.SetActive(true);
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = $"Score:\r\n{DataManager.Instance.UserName} {score}";
        if (score > DataManager.Instance.HighScoreValue)
        {
            DataManager.Instance.HighScoreUserName = DataManager.Instance.UserName;
            DataManager.Instance.HighScoreValue = score;
            bestScoreText.text = $"Best Score:\r\n{DataManager.Instance.HighScoreUserName} {DataManager.Instance.HighScoreValue}";
            DataManager.Instance.SaveHighScore();
        }
    }

    IEnumerator SpawnTargets()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            var totalEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
            if (totalEnemies == DataManager.Instance.Level) continue;
            var index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    // void SpawnTargets2()
    // {
    //         var totalEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
    //         if (totalEnemies == maxEnemies) return;
    //         var index = Random.Range(0, targets.Count);
    //         Instantiate(targets[index]);
    // }
}
