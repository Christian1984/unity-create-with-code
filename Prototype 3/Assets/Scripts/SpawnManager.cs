using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private Vector3 spawnPosition = new Vector3(0, 0, 0);
    [SerializeField] private float spawnDelayMin = 0;
    [SerializeField] private float spawnDelayMax = 0;

    private PlayerController playerController;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        SpawnObstacle();
    }

    void SpawnObstacle() {
        if (obstaclePrefab && playerController && !playerController.isGameOver)
        {
            Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
            Invoke("SpawnObstacle", Random.Range(spawnDelayMin, spawnDelayMax));
        }
    }
}
