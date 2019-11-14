using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverOnDeath : MonoBehaviour
{
    public void TriggerGameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
