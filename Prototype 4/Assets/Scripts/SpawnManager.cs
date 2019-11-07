using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab = null;
    [SerializeField] private GameObject powerupPrefab = null;

    [SerializeField] private float maxSpawnRadius = 0;
    [SerializeField] private float minDistanceFromPlayer = 0;

    [SerializeField] private float spawnInterval = 0;

    private GameObject player;
    private int wave = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        //if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
        if (GameObject.FindObjectsOfType<EnemyController>().Length <= 0)
        {
            wave++;

            for (int i = 0; i < wave; i++)
            {
                SpawnEnemy();
            }

            SpawnPowerup();
        }
    }

    private void SpawnEnemy()
    {
        if (enemyPrefab && player)
        {
            Vector3 spawnPos = GetSpawnPos();
            GameObject.Instantiate(enemyPrefab, spawnPos, enemyPrefab.transform.rotation);
        }
    }

    private void SpawnPowerup()
    {
        if (powerupPrefab && player)
        {
            Vector3 spawnPos = GetSpawnPos();
            GameObject.Instantiate(powerupPrefab, spawnPos, enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GetSpawnPos()
    {
        while(true)
        {
            Vector3 spawnPos = Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * Random.Range(0, maxSpawnRadius);

            if (Vector3.Distance(player.transform.position, spawnPos) >= minDistanceFromPlayer)
            {
                return spawnPos;
            }
        }
    }
}
