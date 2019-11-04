using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float _gravityModifier = 1;
    [SerializeField] private float _speedIncreaseInterval = 1;
    [SerializeField] private float _speedIncreaseAmount = 1;
    
    public static GameManager instance;

    public static float gravityModifier { get { return instance._gravityModifier; }}
    public static float speedIncreaseInterval { get { return instance._speedIncreaseInterval; }}
    public static float speedIncreaseAmount { get { return instance._speedIncreaseAmount; }}

    private static PlayerController playerController;

    void Awake() 
    {
        if (!instance)
        {
            instance = this;
            playerController = GameObject.Find("Player").GetComponent<PlayerController>();

            IncreaseSpeed();
        }
    }

    void Update() 
    {
        Physics.gravity = Vector3.down * gravityModifier * 10;
    }

    void IncreaseSpeed()
    {
        if (playerController) 
        {
            playerController.IncreaseSpeed(speedIncreaseAmount);
        }

        Invoke("IncreaseSpeed", speedIncreaseInterval);
    }
}
