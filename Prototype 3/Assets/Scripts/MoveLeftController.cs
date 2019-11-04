using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftController : MonoBehaviour
{
    private PlayerController playerController;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController && !playerController.isGameOver)
        {
            transform.Translate(Vector3.left * playerController.GetSpeed() * Time.deltaTime);
        }
    }
}
