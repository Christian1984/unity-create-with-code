using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab = null;

    [SerializeField] private float maxSpawnRadius = 0;
    [SerializeField] private float minDistanceFromPlayer = 0;

    [SerializeField] private float spawnInterval = 0;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        if (enemyPrefab && player)
        {
            while(true)
            {
                Vector3 spawnPos = Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * Random.Range(0, maxSpawnRadius);

                if (Vector3.Distance(player.transform.position, spawnPos) >= minDistanceFromPlayer)
                {
                    GameObject.Instantiate(enemyPrefab, spawnPos, enemyPrefab.transform.rotation);
                    break;
                }
            }
        }

        Invoke("SpawnEnemy", spawnInterval);
    }
}
