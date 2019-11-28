using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText = null;

    [SerializeField] Canvas gameOverUI = null;
    [SerializeField] Canvas mainMenuUI = null;
    [SerializeField] Canvas gameplayUI = null;

    private SpawnManager spawnManager = null;

    private int score = 0;
    private bool gameOver = true;

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.FindObjectOfType<SpawnManager>();
        AddScore(0);
    }

    public void AddScore(int addScore)
    {
        score += addScore;
        
        if (scoreText)
        {
            scoreText.text = "Score: " + score;
        }
    }

    public bool IsGameOver()
    {
        return gameOver;
    }

    public void GameOver()
    {
        gameOverUI?.gameObject.SetActive(true);
        gameOver = true;
        spawnManager?.StopSpawning();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        gameOver = false;
        spawnManager?.StartSpawning(difficulty);

        mainMenuUI?.gameObject.SetActive(false);
        gameplayUI?.gameObject.SetActive(true);
    }
}
