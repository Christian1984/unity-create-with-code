using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText = null;
    [SerializeField] TextMeshProUGUI gameOverText = null;
    [SerializeField] Button restartButton = null;

    private int score = 0;
    private bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
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
        gameOverText?.gameObject.SetActive(true);
        restartButton?.gameObject.SetActive(true);

        gameOver = true;

        SpawnManager spawnManager = GameObject.FindObjectOfType<SpawnManager>();
        spawnManager?.StopSpawning();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
