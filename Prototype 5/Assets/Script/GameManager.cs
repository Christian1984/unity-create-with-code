using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText = null;

    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        AddScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int addScore)
    {
        score += addScore;
        
        if (scoreText)
        {
            scoreText.text = "Score: " + score;
        }
    }
}
